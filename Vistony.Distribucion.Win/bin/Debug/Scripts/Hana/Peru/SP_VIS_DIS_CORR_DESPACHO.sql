CREATE PROCEDURE SP_VIS_DIS_SEARCHOPERATIONS
(
IN DESDE VARCHAR(20),
IN HASTA VARCHAR(20),
IN CONSOLIDADO VARCHAR(1),
IN AGENCIA VARCHAR(1),
IN USUARIO VARCHAR(50)
)
AS
QCONSOL VARCHAR(200);
QAGENCIA VARCHAR(200);

BEGIN

QCONSOL := '';

IF CONSOLIDADO = 'Y' THEN
	QCONSOL := ' AND IFNULL(A.U_SYP_DT_CONSOL, '''') <> '''' ';
ELSE
	QCONSOL := ' AND IFNULL(A.U_SYP_DT_CONSOL, '''') = '''' ';
END IF;

QAGENCIA := '';
IF :AGENCIA = 'Y' THEN
	QAGENCIA := ' AND IFNULL(A."U_VIS_AgencyCode",'''') <> '''' ';
ELSE
	QAGENCIA := ' AND IFNULL(A."U_VIS_AgencyCode",'''') = '''' ';
END IF;

EXECUTE IMMEDIATE
(
	'SELECT
		'''' as "Marca" ,A."DocEntry",A."DocNum" "Entrega", A."TaxDate" "Fecha", A."NumAtCard" "Numero Legal", A."DocDueDate" "FechaFinal",
		A."CardCode" "CodigoSN", A."CardName" "NombreSN","Ubigeo", A.U_SYP_MDTD "Tipo", IFNULL(A.U_SYP_DT_CONSOL, '''') "Consolidado", 
		IFNULL(A.U_SYP_DT_FCONSOL, '''') "FConsolidacion", IFNULL(A.U_SYP_DT_HCONSOL, '''') "HConsolidacion", 
		O."DocDueDate" "FReq",
		T.PESO "Peso", 0 AS INDIC
	FROM ODLN A 
	INNER JOIN
	(
		SELECT TDOC."U_SYP_NDSD"
		FROM OUSR TU
		INNER JOIN "@SYP_NUMDOC" TDOC ON TDOC."Code" = ''09'' AND TU."U_SYP_NDED" = TDOC."U_SYP_NDED"
		WHERE
		"USER_CODE" = '''|| :USUARIO ||'''
		ORDER BY TDOC."U_SYP_NDSD"
	) SER ON SER."U_SYP_NDSD" = A."U_SYP_MDSD"
	INNER JOIN 
			(SELECT
				"DocEntry",SUM((SELECT "IWeight1" FROM OITM WHERE "ItemCode" = D."ItemCode")*D."Quantity" ) "PESO" 
			FROM
				DLN1 D Group By "DocEntry") T  ON T."DocEntry" = A."DocEntry"	
	INNER JOIN (SELECT "DocEntry", "BaseType"  FROM DLN1 GROUP BY "DocEntry","BaseType" ) A1 ON A."DocEntry" = A1."DocEntry" 
	LEFT JOIN (SELECT "DocEntry","TrgetEntry" FROM RDR1 	GROUP BY "DocEntry","TrgetEntry") O1 ON A1."DocEntry" = O1."TrgetEntry"
	LEFT JOIN  ORDR O ON O1."DocEntry" = O."DocEntry"
	LEFT JOIN (SELECT "DocEntry",UPPER("CityS" ||''-''|| "CountyS" ||''-''|| "BlockS") "Ubigeo" FROM DLN12) U ON
	U."DocEntry"=A."DocEntry"
	WHERE 
		A."TaxDate" BETWEEN  ('''|| :DESDE ||''') 
	 			AND  ('''|| :HASTA ||''')
	AND A.CANCELED = ''N''
	AND IFNULL(A."U_SYP_DT_ESTDES",''S'')IN (''S'', ''V'', ''P'') ' || :QCONSOL  || ' ' || :QAGENCIA  || ' '
 );

END;