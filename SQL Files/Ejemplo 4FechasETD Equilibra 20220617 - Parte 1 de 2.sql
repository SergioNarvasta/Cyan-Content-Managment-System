Select * From CEX_Importacion
-- 2066
Select * From CEX_ImportacionETD
-- 4169
Select Max(NroSec) From CEX_ImportacionETD
-- Una importacion tiene 7 fechas



Select x.cia_codcia, x.IdImportacion, x.CodigoImportacion,
Max(x.FechaETD01) as FechaETD01,
Max(x.FechaETD02) as FechaETD02,
Max(x.FechaETD03) as FechaETD03,
Max(x.FechaETD04) as FechaETD04,
Max(x.FechaETD05) as FechaETD05,
Max(x.FechaETD06) as FechaETD06,
Max(x.FechaETD07) as FechaETD07
From 
(
Select 
a.cia_codcia, a.IdImportacion, A.CodigoImportacion, 
(case when b.NroSec=1 then b.FechaETD else null end) as FechaETD01,
(case when b.NroSec=2 then b.FechaETD else null end) as FechaETD02,
(case when b.NroSec=3 then b.FechaETD else null end) as FechaETD03,
(case when b.NroSec=4 then b.FechaETD else null end) as FechaETD04,
(case when b.NroSec=5 then b.FechaETD else null end) as FechaETD05,
(case when b.NroSec=6 then b.FechaETD else null end) as FechaETD06,
(case when b.NroSec=7 then b.FechaETD else null end) as FechaETD07
From CEX_Importacion A
Left Join CEX_ImportacionETD b on a.cia_codcia=b.cia_codcia and a.IdImportacion=b.IdImportacion
) as X
Group by x.cia_codcia, x.IdImportacion, x.CodigoImportacion




