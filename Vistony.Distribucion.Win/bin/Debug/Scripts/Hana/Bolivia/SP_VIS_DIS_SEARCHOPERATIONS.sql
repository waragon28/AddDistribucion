ALTER PROCEDURE SP_VIS_DIS_SEARCHOPERATIONS
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
		A."CardCode" "CodigoSN", A."CardName" "NombreSN",'''' as "Ubigeo", '''' "Tipo", IFNULL(A.U_SYP_DT_CONSOL, '''') "Consolidado", 
		IFNULL(A.U_SYP_DT_FCONSOL, '''') "FConsolidacion", IFNULL(A.U_SYP_DT_HCONSOL, '''') "HConsolidacion", 
		O."DocDueDate" "FReq",
		T.PESO "Peso", 0 AS INDIC
	FROM OINV A 
	INNER JOIN
	(
		SELECT TU."U_SYP_NDED",OU."Name" as "U_SYP_NDSD"
		FROM OUSR TU
		INNER JOIN OUBR OU ON OU."Code"=TU."Branch"
		WHERE
		"USER_CODE" = '''|| :USUARIO ||'''
	) SER ON SER."U_SYP_NDSD" = A."U_VIST_SUCUSU"
	INNER JOIN 
			(SELECT
				"DocEntry",SUM((SELECT "IWeight1" FROM OITM WHERE "ItemCode" = D."ItemCode")*D."Quantity" ) "PESO" 
			FROM
				INV1 D Group By "DocEntry") T  ON T."DocEntry" = A."DocEntry"	
	INNER JOIN (SELECT "DocEntry", "BaseType"  FROM INV1 GROUP BY "DocEntry","BaseType" ) A1 ON A."DocEntry" = A1."DocEntry" 
	LEFT JOIN (SELECT "DocEntry","TrgetEntry" FROM RDR1 	GROUP BY "DocEntry","TrgetEntry") O1 ON A1."DocEntry" = O1."TrgetEntry"
	LEFT JOIN  ORDR O ON O1."DocEntry" = O."DocEntry"
	WHERE 
		A."TaxDate" BETWEEN  ('''|| :DESDE ||''') 
	 			AND  ('''|| :HASTA ||''')
	AND A.CANCELED = ''N''
	AND IFNULL(A."U_SYP_DT_ESTDES",''S'')IN (''S'', ''V'', ''P'') ' || :QCONSOL  || ' ' || :QAGENCIA  || ' '
 );

END;