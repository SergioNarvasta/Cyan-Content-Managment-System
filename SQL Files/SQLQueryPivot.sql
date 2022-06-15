


--Where YEAR(b.FechaETD)>=2022 and a.CodigoImportacion ='MF06500022' 
--group by a.CodigoImportacion,b.IdImportacion
--group by b.FechaETD,b.NroSec
/*
Select  a.CodigoImportacion,ETD.Fecha7,ETD.Fecha6,ETD.Fecha5,ETD.Fecha4,ETD.Fecha3,ETD.Fecha2,ETD.Fecha1 
From CEX_Importacion A left join (
      Select b.cia_codcia,b.IdImportacion,
      (Case When b.NroSec=7 Then b.FechaETD End)AS Fecha7,
      (Case When b.NroSec=6 Then b.FechaETD End)AS Fecha6,
      (Case When b.NroSec=5 Then b.FechaETD End)AS Fecha5,
      (Case When b.NroSec=4 Then b.FechaETD End)AS Fecha4,
      (Case When b.NroSec=3 Then b.FechaETD End)AS Fecha3,
      (Case When b.NroSec=2 Then b.FechaETD End)AS Fecha2,
      (Case When b.NroSec=1 Then b.FechaETD End)AS Fecha1 FROM CEX_ImportacionETD b group  by b.cia_codcia,b.IdImportacion,b.NroSec,b.FechaETD )AS ETD 
   ON (a.cia_codcia=ETD.cia_codcia and a.IdImportacion=ETD.IdImportacion )
--Where ETD.Fecha1 IS NOT NULL 
group by a.CodigoImportacion,ETD.Fecha7,ETD.Fecha6,ETD.Fecha5,ETD.Fecha4,ETD.Fecha3,ETD.Fecha2,ETD.Fecha1
GO
*/

SELECT *
FROM (SELECT fETD.CodigoImportacion,fETD.NroFecha,ISNULL(fETD.Fecha,'')as Fecha
      FROM CEX_Importacion A left join(
	  Select a.CodigoImportacion,'Fecha7'AS NroFecha,b.FechaETD AS Fecha From CEX_Importacion A left join CEX_ImportacionETD b ON (a.cia_codcia=b.cia_codcia and a.IdImportacion=b.IdImportacion)Where b.NroSec=7 UNION
      Select a.CodigoImportacion,'Fecha6'AS NroFecha,b.FechaETD AS Fecha From CEX_Importacion A left join CEX_ImportacionETD b ON (a.cia_codcia=b.cia_codcia and a.IdImportacion=b.IdImportacion)Where b.NroSec=6 UNION
      Select a.CodigoImportacion,'Fecha5'AS NroFecha,b.FechaETD AS Fecha From CEX_Importacion A left join CEX_ImportacionETD b ON (a.cia_codcia=b.cia_codcia and a.IdImportacion=b.IdImportacion)Where b.NroSec=5 UNION
      Select a.CodigoImportacion,'Fecha4'AS NroFecha,b.FechaETD AS Fecha From CEX_Importacion A left join CEX_ImportacionETD b ON (a.cia_codcia=b.cia_codcia and a.IdImportacion=b.IdImportacion)Where b.NroSec=4 UNION
      Select a.CodigoImportacion,'Fecha3'AS NroFecha,b.FechaETD AS Fecha From CEX_Importacion A left join CEX_ImportacionETD b ON (a.cia_codcia=b.cia_codcia and a.IdImportacion=b.IdImportacion)Where b.NroSec=3 UNION
      Select a.CodigoImportacion,'Fecha2'AS NroFecha,b.FechaETD AS Fecha From CEX_Importacion A left join CEX_ImportacionETD b ON (a.cia_codcia=b.cia_codcia and a.IdImportacion=b.IdImportacion)Where b.NroSec=2 UNION
      Select a.CodigoImportacion,'Fecha1'AS NroFecha,b.FechaETD AS Fecha From CEX_Importacion A left join CEX_ImportacionETD b ON (a.cia_codcia=b.cia_codcia and a.IdImportacion=b.IdImportacion)Where b.NroSec=1
	  )AS fETD on a.CodigoImportacion = fETD.CodigoImportacion
)AS pvt PIVOT(max(Fecha) FOR NroFecha IN(Fecha7,Fecha6,Fecha5,Fecha4,Fecha3,Fecha2,Fecha1)) AS PivotTable


GO

With pETD AS(
Select a.CodigoImportacion,'Fecha7'AS NroFecha,b.FechaETD AS Fecha From CEX_Importacion A left join CEX_ImportacionETD b ON (a.cia_codcia=b.cia_codcia and a.IdImportacion=b.IdImportacion)Where b.NroSec=7 UNION
Select a.CodigoImportacion,'Fecha6'AS NroFecha,b.FechaETD AS Fecha From CEX_Importacion A left join CEX_ImportacionETD b ON (a.cia_codcia=b.cia_codcia and a.IdImportacion=b.IdImportacion)Where b.NroSec=6 UNION
Select a.CodigoImportacion,'Fecha5'AS NroFecha,b.FechaETD AS Fecha From CEX_Importacion A left join CEX_ImportacionETD b ON (a.cia_codcia=b.cia_codcia and a.IdImportacion=b.IdImportacion)Where b.NroSec=5 UNION
Select a.CodigoImportacion,'Fecha4'AS NroFecha,b.FechaETD AS Fecha From CEX_Importacion A left join CEX_ImportacionETD b ON (a.cia_codcia=b.cia_codcia and a.IdImportacion=b.IdImportacion)Where b.NroSec=4 UNION
Select a.CodigoImportacion,'Fecha3'AS NroFecha,b.FechaETD AS Fecha From CEX_Importacion A left join CEX_ImportacionETD b ON (a.cia_codcia=b.cia_codcia and a.IdImportacion=b.IdImportacion)Where b.NroSec=3 UNION
Select a.CodigoImportacion,'Fecha2'AS NroFecha,b.FechaETD AS Fecha From CEX_Importacion A left join CEX_ImportacionETD b ON (a.cia_codcia=b.cia_codcia and a.IdImportacion=b.IdImportacion)Where b.NroSec=2 UNION
Select a.CodigoImportacion,'Fecha1'AS NroFecha,b.FechaETD AS Fecha From CEX_Importacion A left join CEX_ImportacionETD b ON (a.cia_codcia=b.cia_codcia and a.IdImportacion=b.IdImportacion)Where b.NroSec=1
)

/*
SELECT A.CodigoImportacion,b.IdImportacion,B.FechaETD
FROM CEX_Importacion A left join CEX_ImportacionETD b ON (a.cia_codcia=B.cia_codcia and a.IdImportacion=B.IdImportacion )
ORDER BY A.CodigoImportacion
*/


--Cooper v16 Unidad P
--tin -prd
--linea - prd
--fam --prd


/*
Select a.CodigoImportacion,
COALESCE( 
ETD.Fecha7,ETD.Fecha6,ETD.Fecha5,ETD.Fecha4,ETD.Fecha3,ETD.Fecha2,ETD.Fecha1 
)AS FECHA7,COALESCE(ETD.Fecha6,ETD.Fecha5,ETD.Fecha4,ETD.Fecha3,ETD.Fecha2,ETD.Fecha1 
)AS FECHA7
From CEX_Importacion A left join (
      Select b.cia_codcia,b.IdImportacion,
      (Case When b.NroSec=7 Then b.FechaETD End)AS Fecha7,
      (Case When b.NroSec=6 Then b.FechaETD End)AS Fecha6,
      (Case When b.NroSec=5 Then b.FechaETD End)AS Fecha5,
      (Case When b.NroSec=4 Then b.FechaETD End)AS Fecha4,
      (Case When b.NroSec=3 Then b.FechaETD End)AS Fecha3,
      (Case When b.NroSec=2 Then b.FechaETD End)AS Fecha2,
      (Case When b.NroSec=1 Then b.FechaETD End)AS Fecha1 FROM CEX_ImportacionETD b)AS ETD 
   ON (a.cia_codcia=ETD.cia_codcia and a.IdImportacion=ETD.IdImportacion)
group by a.CodigoImportacion,ETD.Fecha7,ETD.Fecha6,ETD.Fecha5,ETD.Fecha4,ETD.Fecha3,ETD.Fecha2,ETD.Fecha1

*/

go
 
 --SELECT * FROM  CEX_ImportacionETD 
 GO
--(SELECT cia_codcia,IdImportacion,count(NroSec)AS cant FROM CEX_ImportacionETD group by cia_codcia,IdImportacion)
--left join AS cETD ON (a.cia_codcia=cETD.cia_codcia and a.IdImportacion=cETD.IdImportacion)


/*
Select *
From
(
  Select top 4
      a.CodigoImportacion,b.IdImportacion, B.FechaETD       
   From CEX_Importacion A
	left join CEX_ImportacionETD b on (a.cia_codcia = b.cia_codcia and a.IdImportacion = b.IdImportacion )
   Where YEAR(b.FechaETD)>=2022 and a.CodigoImportacion ='MF06500022'  
   Order by b.NroSec desc
)AS SourceTb 
PIVOT( 
    AVG(FechaETD) 
	FOR  (FechaETD) IN ([FechaETD4],[FechaETD3],[FechaETD2],[FechaETD1])

)AS PivotTable
go
*/