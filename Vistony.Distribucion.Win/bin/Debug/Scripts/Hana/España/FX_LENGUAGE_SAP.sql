CREATE FUNCTION FX_LENGUAGE_SAP(IN SYSLENG INT)
RETURNS LENGUAGETEXTO VARCHAR(50)
AS 
BEGIN
DECLARE LENGUAJE VARCHAR(50);
SELECT
	(
	   CASE WHEN SYSLENG=32 THEN 'Arabic'
			WHEN SYSLENG=26 THEN 'Czech (Czech)'
			WHEN SYSLENG=11 THEN 'Danish (Denmark)'
			WHEN SYSLENG=16 THEN 'Dutch (Netherlands)'
			WHEN SYSLENG=3 THEN 'English (United States)'
			WHEN SYSLENG=8 THEN 'English (United Kingdom)'
			WHEN SYSLENG=17 THEN 'Finnish (Finland)'
			WHEN SYSLENG=22 THEN 'French'
			WHEN SYSLENG=9 THEN 'German'
			WHEN SYSLENG=18 THEN 'Greek (Greece)'
			WHEN SYSLENG=1 THEN 'Hebrew (Israel)'
			WHEN SYSLENG=14 THEN 'Hungarian (Hungary)'
			WHEN SYSLENG=13 THEN 'Italian (Italy)'
			WHEN SYSLENG=30 THEN 'Japanese (Japan)'
			WHEN SYSLENG=28 THEN 'Korean (Korean)'
			WHEN SYSLENG=12 THEN 'Norwegian (Norway)'
			WHEN SYSLENG=5 THEN 'Polish (Poland)'
			WHEN SYSLENG=29 THEN 'Portuguese (Brazil)'
			WHEN SYSLENG=19 THEN 'Portuguese'
			WHEN SYSLENG=24 THEN 'Russian (Russia)'
			WHEN SYSLENG=15 THEN 'Simplified Chinese (P.R.China)'
			WHEN SYSLENG=27 THEN 'Slovak (Slovakia)'
			WHEN SYSLENG=25 THEN 'Spanish (Latin America)'
			WHEN SYSLENG=23 THEN 'Spanish (Spain)'
			WHEN SYSLENG=20 THEN 'Swedish (Sweden)'
			WHEN SYSLENG=35 THEN 'Traditional Chinese'
			WHEN SYSLENG=3 THEN 'Turkish'
			WHEN SYSLENG=33 THEN 'Ukrainian'
			ELSE '' END
	) INTO LENGUAJE FROM DUMMY;
	
LENGUAGETEXTO := LENGUAJE;

END;