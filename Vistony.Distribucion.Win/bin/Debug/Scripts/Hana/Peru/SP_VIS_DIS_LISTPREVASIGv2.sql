CREATE PROCEDURE "SP_VIS_DIS_LISTPREVASIGv2"
(
IN FECHENTR1 VARCHAR(10),
IN FECHENTR2 VARCHAR(10),
IN USUARIO VARCHAR(20),
IN CHOFER VARCHAR(30),
IN AGENCIA VARCHAR(1)
)
AS
BEGIN
	IF :CHOFER ='' THEN
		SELECT
		'' "Marca", 
		CD."DocEntry",
		CD."DocNum" "Entrega", 
		CD."TaxDate" "DocDueDate", 
		CD."NumAtCard", 
		CD."CardCode", 
		CD."CardName",
		CD1."Peso",
		(CASE WHEN IFNULL("U_VIS_AgencyName",'')=''  THEN "U_SYP_MDNT" ELSE  "U_VIS_AgencyName" END) "Transporte",
		"U_SYP_DT_CONSOL" AS "Consolidado",
		"U_SYP_DT_FCONSOL" "FechaConsolidado",
		(CASE WHEN IFNULL("U_VIS_AgencyName",'')=''  THEN DX."City"||'-'||DX."County"||'-'|| DX."Block" ELSE  AG."City"||'-'||AG."County"||'-'|| AG."Block"  END) "Ubigeo",
		EDIR."StreetS" || '-' || EDIR."BlockS" || '-' || EDIR."CityS" || '-' || EDIR."CountyS" AS "Direccion" ,
		IFNULL(T20."Code",'') "CodChofer",
		IFNULL(T20."Name",'') AS "Chofer",
		IFNULL(T21."Code",'') "CodVehiculo",
		IFNULL(T21."U_SYP_VEPL",'') AS "Vehiculo",
		IFNULL(T22."Code",'') "CodAyudante",
		IFNULL(T22."Name",'') "Ayudante",
		OI."NumAtCard" "NroFactura",
		OI."DocEntry" "DocEntry_Fac",
		T20."U_SYP_CHLI" "LicenciaChofer",
		IFNULL(T21."U_SYP_VEMA",'') "MarcaVehiculo",
		EM."salesPrson" "Vendedor_ID",
		UPPER(IFNULL("lastName",'') || ' ' ||  IFNULL("firstName",'') || ' ' ||  IFNULL("middleName",''))   "Vendedor",
		"Saldo",
		"TerminoPago"
		FROM ODLN CD
		LEFT JOIN 
		(SELECT ED."DocEntry", IFNULL(SUM(IFNULL(ED."Quantity",0)*IFNULL("IWeight1",0)),0) "Peso",
		        MAX("TargetType")"TargetType",MAX("TrgetEntry")"TrgetEntry"
		 FROM DLN1 ED INNER JOIN OITM ON OITM."ItemCode" = ED."ItemCode" GROUP BY ED."DocEntry") CD1
		 ON CD."DocEntry" = CD1."DocEntry"
		LEFT JOIN (SELECT "CardCode" ,"Address","ZipCode","City","County","Block","Street","U_VIS_SlpCode" FROM CRD1 WHERE "AdresType"='S') DX ON
		DX."CardCode" =CD."CardCode" AND
		DX."Address"=CD."ShipToCode"
		INNER JOIN DLN12 EDIR ON EDIR."DocEntry" = CD."DocEntry"
		INNER JOIN
			(
				SELECT TDOC."U_SYP_NDSD"
				FROM OUSR TU
				INNER JOIN "@SYP_NUMDOC" TDOC ON TDOC."Code" = '09' AND TU."U_SYP_NDED" = TDOC."U_SYP_NDED"
				WHERE
				"USER_CODE" = ''||:USUARIO||''
				ORDER BY TDOC."U_SYP_NDSD"
			) SER ON SER."U_SYP_NDSD" = CD."U_SYP_MDSD"
		LEFT JOIN (SELECT 
					T0."CardCode",T1."Block", T1."City" , T1."County" ,T1."ZipCode"
					FROM OCRD T0
					INNER JOIN (SELECT * FROM CRD1 WHERE "AdresType"='S' and "Address"='01' ) T1 ON
					T0."CardCode"=T1."CardCode") AG ON
					AG."CardCode"=CD."U_VIS_AgencyCode"
		LEFT JOIN "@VIST_UBIGEOCHOFER" UBI ON DX."ZipCode" = UBI."U_VIS_CodUbigeo"
		LEFT JOIN "@SYP_CONDUC" T20 ON UBI."U_VIS_CodChofer"=T20."U_SYP_FEGND"
		LEFT JOIN "@SYP_VEHICU" T21 ON T20."U_VIS_Vehiculo"=T21."U_SYP_VEPL"
		LEFT JOIN "@VIS_DIS_OAYD" T22 ON T22."Code"= "U_VIS_AydCode"
		LEFT JOIN (SELECT "DocEntry","NumAtCard","DocNum",TO_DECIMAL("DocTotal" - "PaidToDate",14,4) "Saldo", "PymntGroup" "TerminoPago" FROM OINV T0
					INNER JOIN OCTG T1 ON
					T0."GroupNum"=T1."GroupNum" ) OI ON
			OI."DocEntry"=CD1."TrgetEntry" AND
			'13'=CD1."TargetType"
		LEFT JOIN (SELECT * FROM OHEM  where IFNULL("salesPrson",0)>0) EM ON
			CAST(EM."salesPrson" AS VARCHAR(10))=CAST(DX."U_VIS_SlpCode" AS VARCHAR(10))
		WHERE
			(CASE WHEN UPPER(AGENCIA)='N' AND IFNULL(CD."U_VIS_AgencyCode",'')= '' THEN 'N'
		    	  WHEN UPPER(AGENCIA)='Y' AND IFNULL(CD."U_VIS_AgencyCode",'')<> '' THEN 'Y'
		    END)=AGENCIA
		    
		    AND
			CD."DocType" = 'I' AND IFNULL(CD."CANCELED",'N') = 'N'
	
		AND IFNULL(CD."U_SYP_DT_ESTDES",'S')  IN ('S', 'V')
		AND 
			CD."TaxDate" BETWEEN :FECHENTR1 AND :FECHENTR2
		ORDER BY CD."DocNum";
	ELSE
		SELECT
		'Y' "Marca", 
		CD."DocEntry",
		CD."DocNum" "Entrega", 
		CD."TaxDate" "DocDueDate", 
		CD."NumAtCard", 
		CD."CardCode", 
		CD."CardName",
		CD1."Peso",
		(CASE WHEN IFNULL("U_VIS_AgencyName",'')=''  THEN "U_SYP_MDNT" ELSE  "U_VIS_AgencyName" END) "Transporte",
		"U_SYP_DT_CONSOL" AS "Consolidado",
		"U_SYP_DT_FCONSOL" "FechaConsolidado",
		(CASE WHEN IFNULL("U_VIS_AgencyName",'')=''  THEN DX."City"||'-'||DX."County"||'-'|| DX."Block" ELSE  AG."City"||'-'||AG."County"||'-'|| AG."Block"  END) "Ubigeo",
		EDIR."StreetS" || '-' || EDIR."BlockS" || '-' || EDIR."CityS" || '-' || EDIR."CountyS" AS "Direccion" ,
		IFNULL(T20."Code",'') "CodChofer",
		IFNULL(T20."Name",'') AS "Chofer",
		IFNULL(T21."Code",'') "CodVehiculo",
		IFNULL(T21."U_SYP_VEPL",'') AS "Vehiculo",
		IFNULL(T22."Code",'') "CodAyudante",
		IFNULL(T22."Name",'') "Ayudante",
		OI."NumAtCard" "NroFactura",
		OI."DocEntry" "DocEntry_Fac",
		T20."U_SYP_CHLI" "LicenciaChofer",
		IFNULL(T21."U_SYP_VEMA",'') "MarcaVehiculo",
		EM."salesPrson" "Vendedor_ID",
		UPPER(IFNULL("lastName",'') || ' ' ||  IFNULL("firstName",'') || ' ' ||  IFNULL("middleName",''))   "Vendedor",
		"Saldo",
		"TerminoPago"
		FROM ODLN CD
		LEFT JOIN 
		(SELECT ED."DocEntry", IFNULL(SUM(IFNULL(ED."Quantity",0)*IFNULL("IWeight1",0)),0) "Peso",
		 MAX("TargetType")"TargetType",MAX("TrgetEntry")"TrgetEntry"
		 FROM DLN1 ED INNER JOIN OITM ON OITM."ItemCode" = ED."ItemCode" GROUP BY ED."DocEntry") CD1
		 ON CD."DocEntry" = CD1."DocEntry"
		LEFT JOIN (SELECT "CardCode" ,"Address","ZipCode","City","County","Block","Street","U_VIS_SlpCode" FROM CRD1 WHERE "AdresType"='S') DX ON
		DX."CardCode" =CD."CardCode" AND
		DX."Address"=CD."ShipToCode"
		INNER JOIN DLN12 EDIR ON EDIR."DocEntry" = CD."DocEntry"
		INNER JOIN
			(
				SELECT TDOC."U_SYP_NDSD"
				FROM OUSR TU
				INNER JOIN "@SYP_NUMDOC" TDOC ON TDOC."Code" = '09' AND TU."U_SYP_NDED" = TDOC."U_SYP_NDED"
				WHERE
				"USER_CODE" = ''||:USUARIO||''
				ORDER BY TDOC."U_SYP_NDSD"
			) SER ON SER."U_SYP_NDSD" = CD."U_SYP_MDSD"
		LEFT JOIN (SELECT 
					T0."CardCode",T1."Block", T1."City" , T1."County" ,T1."ZipCode"
					FROM OCRD T0
					INNER JOIN (SELECT * FROM CRD1 WHERE "AdresType"='S' and "Address"='01' ) T1 ON
					T0."CardCode"=T1."CardCode") AG ON
					AG."CardCode"=CD."U_VIS_AgencyCode"
		LEFT JOIN "@VIST_UBIGEOCHOFER" UBI ON DX."ZipCode" = UBI."U_VIS_CodUbigeo"
		LEFT JOIN "@SYP_CONDUC" T20 ON UBI."U_VIS_CodChofer"=T20."U_SYP_FEGND"
		LEFT JOIN "@SYP_VEHICU" T21 ON T20."U_VIS_Vehiculo"=T21."U_SYP_VEPL"
		LEFT JOIN "@VIS_DIS_OAYD" T22 ON T22."Code"= "U_VIS_AydCode"
		LEFT JOIN (SELECT "DocEntry","NumAtCard","DocNum",TO_DECIMAL("DocTotal" - "PaidToDate",14,4) "Saldo", "PymntGroup" "TerminoPago"  FROM OINV T0
					INNER JOIN OCTG T1 ON
					T0."GroupNum"=T1."GroupNum" ) OI ON
			OI."DocEntry"=CD1."TrgetEntry" AND
			'13'=CD1."TargetType"
		LEFT JOIN (SELECT * FROM OHEM  where IFNULL("salesPrson",0)>0) EM ON
			CAST(EM."salesPrson" AS VARCHAR(10))=CAST(DX."U_VIS_SlpCode" AS VARCHAR(10))
		WHERE
		
		CD."DocType" = 'I' AND IFNULL(CD."CANCELED",'N') = 'N' AND
		IFNULL(CD."U_VIS_AgencyCode",'')= '' AND
		IFNULL(CD."U_SYP_DT_ESTDES",'S')  IN ('S', 'V')
		AND 
			CD."TaxDate" BETWEEN :FECHENTR1 AND :FECHENTR2
		AND UBI."U_VIS_CodChofer" = :CHOFER
		--ORDER BY CD."DocNum"
	
		UNION ALL
	
		SELECT
		'Y' "Marca", 
		CD."DocEntry",
		CD."DocNum" "Entrega", 
		CD."TaxDate" "DocDueDate", 
		CD."NumAtCard", 
		CD."CardCode", 
		CD."CardName",
		CD1."Peso",
		(CASE WHEN IFNULL("U_VIS_AgencyName",'')=''  THEN "U_SYP_MDNT" ELSE  "U_VIS_AgencyName" END) "Transporte",
		"U_SYP_DT_CONSOL" AS "Consolidado",
		"U_SYP_DT_FCONSOL" "FechaConsolidado",
		(CASE WHEN IFNULL("U_VIS_AgencyName",'')=''  THEN DX."City"||'-'||DX."County"||'-'|| DX."Block" ELSE  AG."City"||'-'||AG."County"||'-'|| AG."Block"  END) "Ubigeo",
		EDIR."StreetS" || '-' || EDIR."BlockS" || '-' || EDIR."CityS" || '-' || EDIR."CountyS" AS "Direccion" ,
		IFNULL(T20."Code",'') "CodChofer",
		IFNULL(T20."Name",'') AS "Chofer",
		IFNULL(T21."Code",'') "CodVehiculo",
		IFNULL(T21."U_SYP_VEPL",'') AS "Vehiculo",
		IFNULL(T22."Code",'') "CodAyudante",
		IFNULL(T22."Name",'') "Ayudante",
		OI."NumAtCard" "NroFactura",
		OI."DocEntry" "DocEntry_Fac",
		T20."U_SYP_CHLI" "LicenciaChofer",
		IFNULL(T21."U_SYP_VEMA",'') "MarcaVehiculo",
		EM."salesPrson" "Vendedor_ID",
		UPPER(IFNULL("lastName",'') || ' ' ||  IFNULL("firstName",'') || ' ' ||  IFNULL("middleName",''))   "Vendedor",
		"Saldo",
		"TerminoPago"
		FROM ODLN CD
		LEFT JOIN 
		(SELECT ED."DocEntry", IFNULL(SUM(IFNULL(ED."Quantity",0)*IFNULL("IWeight1",0)),0) "Peso",
		 MAX("TargetType")"TargetType",MAX("TrgetEntry")"TrgetEntry"
		 FROM DLN1 ED INNER JOIN OITM ON OITM."ItemCode" = ED."ItemCode" GROUP BY ED."DocEntry") CD1
		 ON CD."DocEntry" = CD1."DocEntry"
		LEFT JOIN (SELECT "CardCode" ,"Address","ZipCode","City","County","Block","Street","U_VIS_SlpCode" FROM CRD1 WHERE "AdresType"='S') DX ON
		DX."CardCode" =CD."CardCode" AND
		DX."Address"=CD."ShipToCode"
		INNER JOIN DLN12 EDIR ON EDIR."DocEntry" = CD."DocEntry"
		INNER JOIN
			(
				SELECT TDOC."U_SYP_NDSD"
				FROM OUSR TU
				INNER JOIN "@SYP_NUMDOC" TDOC ON TDOC."Code" = '09' AND TU."U_SYP_NDED" = TDOC."U_SYP_NDED"
				WHERE
				"USER_CODE" = ''||:USUARIO||''
				ORDER BY TDOC."U_SYP_NDSD"
			) SER ON SER."U_SYP_NDSD" = CD."U_SYP_MDSD"
		INNER JOIN (SELECT 
					T0."CardCode",T1."Block", T1."City" , T1."County" ,T1."ZipCode"
					FROM OCRD T0
					INNER JOIN (SELECT * FROM CRD1 WHERE "AdresType"='S' and "Address"='01' ) T1 ON
					T0."CardCode"=T1."CardCode") AG ON
					AG."CardCode"=CD."U_VIS_AgencyCode"
		LEFT JOIN "@VIST_UBIGEOCHOFER" UBI ON AG."ZipCode" = UBI."U_VIS_CodUbigeo"
		LEFT JOIN "@SYP_CONDUC" T20 ON UBI."U_VIS_CodChofer"=T20."U_SYP_FEGND"
		LEFT JOIN "@SYP_VEHICU" T21 ON T20."U_VIS_Vehiculo"=T21."U_SYP_VEPL"
		LEFT JOIN "@VIS_DIS_OAYD" T22 ON T22."Code"= "U_VIS_AydCode"
		LEFT JOIN (SELECT "DocEntry","NumAtCard","DocNum",TO_DECIMAL("DocTotal" - "PaidToDate",14,4) "Saldo", "PymntGroup" "TerminoPago"  FROM OINV T0
					INNER JOIN OCTG T1 ON
					T0."GroupNum"=T1."GroupNum" ) OI ON
			OI."DocEntry"=CD1."TrgetEntry" AND
			'13'=CD1."TargetType"
		LEFT JOIN (SELECT * FROM OHEM  where IFNULL("salesPrson",0)>0) EM ON
			CAST(EM."salesPrson" AS VARCHAR(10))=CAST(DX."U_VIS_SlpCode" AS VARCHAR(10))
		WHERE
		
		CD."DocType" = 'I' AND IFNULL(CD."CANCELED",'N') = 'N' AND
		
		 IFNULL(CD."U_SYP_DT_ESTDES",'S')  IN ('S', 'V')
		AND 
			CD."TaxDate" BETWEEN :FECHENTR1 AND :FECHENTR2
		AND UBI."U_VIS_CodChofer" =:CHOFER AND AGENCIA='Y' ;
		--ORDER BY CD."DocNum"; 
	  
  END IF;
		
END;