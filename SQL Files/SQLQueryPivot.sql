

--select*from CEX_ImportacionETD
go
Select top 4
   a.CodigoImportacion,b.IdImportacion,b.NroSec, b.FechaETD          
From CEX_Importacion A
	left join CEX_ImportacionETD b on (a.cia_codcia = b.cia_codcia and a.IdImportacion = b.IdImportacion )
WHERE YEAR(b.FechaETD)>=2022 and a.CodigoImportacion ='MF001A0022'
Order by a.CodigoImportacion,b.NroSec desc

go
Declare @Indice INT

Select 
	SELECT top 1 b.FechaETD FROM CEX_ImportacionETD where b.NroSec= Count(b.NroSec)-1 order by b.NroSec desc)     
From CEX_Importacion A
	left join CEX_ImportacionETD b on (a.cia_codcia = b.cia_codcia and a.IdImportacion = b.IdImportacion )
WHERE YEAR(b.FechaETD)>=2022 and a.CodigoImportacion ='MF001A0022'
Order by a.CodigoImportacion,b.NroSec desc

go


Select b.CodigoImportacion, b.FechaETD ,
         (SELECT top 1 b.FechaETD FROM CEX_ImportacionETD where b.NroSec= Count(b.NroSec)-1 order by b.NroSec desc)

  FROM CEX_Importacion  A
  left join 
   (Select 
   a.CodigoImportacion,b.IdImportacion,b.NroSec, b.FechaETD          
   From CEX_Importacion A
	left join CEX_ImportacionETD b on (a.cia_codcia = b.cia_codcia and a.IdImportacion = b.IdImportacion )
   ) AS b on a.CodigoImportacion = b.CodigoImportacion
 WHERE YEAR(b.FechaETD)>=2022 and a.CodigoImportacion ='MF001A0022'
group by b.CodigoImportacion,b.FechaETD



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
