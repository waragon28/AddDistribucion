using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Vistony.Distribucion.BO;
using Newtonsoft.Json;

namespace Vistony.Distribucion.Win.UltimaMilla
{
    public partial class MapaUltimamILLA : Form
    {

        GMarkerGoogle marker;
        GMapOverlay mapOverlay;
        DataTable dt;
        List<Ubigaciones> ListUbicaciones;
        int FilaSeleccionada = 0;
        double latInicial = -11.764272;
        double LgnInicial = -77.161178;

        public MapaUltimamILLA(List<Ubigaciones> a)
        {
            ListUbicaciones = a;
            InitializeComponent();
        }

        public MapaUltimamILLA()
        {
            InitializeComponent();
        }

        private void MapaUltimamILLA_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 4;

            dataGridView1.Columns[0].Name = "Cliente";
            dataGridView1.Columns[1].Name = "Longitud";
            dataGridView1.Columns[2].Name = "Latitud";
            dataGridView1.Columns[3].Name = "Hora Fin";

            dynamic table = JsonConvert.SerializeObject(ListUbicaciones);
            dynamic m = JsonConvert.DeserializeObject(table);

            foreach (var row in m)
            {
                dataGridView1.Rows.Add(row.Cliente, row.Lat, row.Long,row.HoraFin);
            }

            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(latInicial, LgnInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom=24;
            gMapControl1.Zoom=20;
            gMapControl1.AutoScroll = true;

            //MARCADOR

            mapOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(latInicial,LgnInicial),GMarkerGoogleType.green);
            mapOverlay.Markers.Add(marker);

            //agregar un Tooltip de texto a los marcadores
            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = string.Format("Ubicación: \n Latitud: {0} \n Longitud: {1}", latInicial,LgnInicial);

            //Ahora agregar el mapa y el marcador al map control
            gMapControl1.Overlays.Add(mapOverlay);

        }

        private void SeleccionarRegistro(object sender, DataGridViewCellMouseEventArgs e)
        {
            //monitorear cada vez que el usuario da clic

            FilaSeleccionada = e.RowIndex; //fila seleccionada

            //recuperamos datos del grid y asignamos a los textBox
            txtDescripcion.Text = dataGridView1.Rows[FilaSeleccionada].Cells[0].Value.ToString();
            txtLati.Text = dataGridView1.Rows[FilaSeleccionada].Cells[1].Value.ToString();    
            txtLong.Text = dataGridView1.Rows[FilaSeleccionada].Cells[2].Value.ToString();
            if (txtLati.Text!="" || txtLong.Text != "")
            {
                //se asignan los valores al grid al marcador
                marker.Position = new PointLatLng(Convert.ToDouble(txtLati.Text), Convert.ToDouble(txtLong.Text));

                //Ubicar la posicion del Mapa segun el marcador
                gMapControl1.Position = marker.Position;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            gMapControl1.Overlays.Clear();
            GMapOverlay Poligono = new GMapOverlay("POligono");

            List<PointLatLng> puntos = new List<PointLatLng>();

            // variables para almacenar los datos.

            double lng,lat;

            // Agarramos los datos del grid

            for (int filas = 0; filas < dataGridView1.Rows.Count; filas++)

            {
                if (Convert.ToString(dataGridView1.Rows[filas].Cells[1].Value) != "" &&
                    Convert.ToString(dataGridView1.Rows[filas].Cells[2].Value) != "" )
                {
                    lat = Convert.ToDouble(dataGridView1.Rows[filas].Cells[1].Value);
                    lng = Convert.ToDouble(dataGridView1.Rows[filas].Cells[2].Value);
                    puntos.Add(new PointLatLng(lat, lng));

                    gMapControl1.Position = new PointLatLng(lat, lng);
                }
               
            }
                GMapPolygon poligonoPuntos = new GMapPolygon(puntos, "Poligono");
                Poligono.Polygons.Add(poligonoPuntos);
                gMapControl1.Overlays.Add(Poligono);

                // actualizar el mapa
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
                gMapControl1.Zoom = gMapControl1.Zoom - 1;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            gMapControl1.Overlays.Clear();

            GMapOverlay Ruta = new GMapOverlay("CapaRuta");
            List<PointLatLng> puntos = new List<PointLatLng>();
            // variables para almacenar los datos.
            double lng, lat, Iniciolat=0, Iniciolng=0;
            // Agarramos los datos del gri
            for (int filas = 0; filas < dataGridView1.Rows.Count; filas++)
            {
                if (Convert.ToString(dataGridView1.Rows[filas].Cells[1].Value) != "" &&
                    Convert.ToString(dataGridView1.Rows[filas].Cells[2].Value) != "")
                {
                    lat = Convert.ToDouble(dataGridView1.Rows[filas].Cells[1].Value);
                    lng = Convert.ToDouble(dataGridView1.Rows[filas].Cells[2].Value);
                    puntos.Add(new PointLatLng(lat, lng));
                }
             }

            for (int PrimeraFila1 = 0; PrimeraFila1 < dataGridView1.Rows.Count; PrimeraFila1++)
            {
                if (Convert.ToString(dataGridView1.Rows[PrimeraFila1].Cells[1].Value) != "" &&
                    Convert.ToString(dataGridView1.Rows[PrimeraFila1].Cells[2].Value) != "")
                {
                    Iniciolat = Convert.ToDouble(dataGridView1.Rows[PrimeraFila1].Cells[1].Value);
                    Iniciolng = Convert.ToDouble(dataGridView1.Rows[PrimeraFila1].Cells[2].Value);
                    break;
                }
            }

            GMapRoute PuntosRuta = new GMapRoute(puntos, "Poligono");


            //MARCADOR

            mapOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(Iniciolat, Iniciolng), GMarkerGoogleType.green);
            mapOverlay.Markers.Add(marker);

            //agregar un Tooltip de texto a los marcadores
            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = string.Format("Ubicación: \n Latitud: {0} \n Longitud: {1}", latInicial, LgnInicial);

            //Ahora agregar el mapa y el marcador al map control
            gMapControl1.Overlays.Add(mapOverlay);


            Ruta.Routes.Add(PuntosRuta);
            gMapControl1.Overlays.Add(Ruta); 
            // actualizar el mapa
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleSatelliteMap;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleTerrainMap;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // trackBar1.Value = Convert.ToInt32(gMapControl1.Zoom);

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
          //  gMapControl1.Zoom = trackBar1.Value;
        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // se obtiene los datos de lat y Ing del mapa donde usuario presiono
            double lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
            // selposicionan en el txt de la latitud y longitud

            txtLati.Text = lat.ToString();

            txtLong.Text = lng.ToString();

            // Creamos el marcador para moverlo al lugar indicado

            marker.Position = new PointLatLng(lat, lng);

            // También se agrega el mensaje al marcador(tooltip)

            marker.ToolTipText = string.Format("Ubicacién: \n Latitud: {0} \n Longitud:{1}", lat, lng);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
