CREATE PROCEDURE SP_VIS_DIS_GETSTATE
AS
BEGIN
SELECT '01' "Value", 'Consolidado 01' "Display" FROM DUMMY
UNION ALL
SELECT '02' "Value", 'Consolidado 02' "Display" FROM DUMMY
UNION ALL
SELECT '03' "Value", 'Consolidado 03' "Display" FROM DUMMY
UNION ALL
SELECT '04' "Value", 'Consolidado 04' "Display" FROM DUMMY
UNION ALL
SELECT '05' "Value", 'Consolidado 05' "Display" FROM DUMMY;
END
