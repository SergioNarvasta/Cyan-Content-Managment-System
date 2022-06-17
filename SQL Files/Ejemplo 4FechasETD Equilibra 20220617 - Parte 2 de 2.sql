Select 
a.cia_codcia, a.IdImportacion, A.CodigoImportacion, 
c.MaxSec,
(Case when c.MaxSec>4 
     then (case when b.NroSec=(c.MaxSec-4+1) then b.FechaETD else null end)
	 else (case when b.NroSec=1 then b.FechaETD else null end) 
	 end) as FechaETD1,
(Case when c.MaxSec>4 
     then (case when b.NroSec=(c.MaxSec-4+2) then b.FechaETD else null end)
	 else (case when b.NroSec=2 then b.FechaETD else null end) 
	 end) as FechaETD2,
(Case when c.MaxSec>4 
     then (case when b.NroSec=(c.MaxSec-4+3) then b.FechaETD else null end)
	 else (case when b.NroSec=3 then b.FechaETD else null end) 
	 end) as FechaETD3,
(Case when c.MaxSec>4 
     then (case when b.NroSec=(c.MaxSec-4+4) then b.FechaETD else null end)
	 else (case when b.NroSec=4 then b.FechaETD else null end) 
	 end) as FechaETD4,
(case when b.NroSec=1 then b.FechaETD else null end) as FechaETD01,
(case when b.NroSec=2 then b.FechaETD else null end) as FechaETD02,
(case when b.NroSec=3 then b.FechaETD else null end) as FechaETD03,
(case when b.NroSec=4 then b.FechaETD else null end) as FechaETD04,
(case when b.NroSec=5 then b.FechaETD else null end) as FechaETD05,
(case when b.NroSec=6 then b.FechaETD else null end) as FechaETD06,
(case when b.NroSec=7 then b.FechaETD else null end) as FechaETD07
From CEX_Importacion A
Left Join (Select cia_codcia, IdImportacion, max(NroSec) as MaxSec From CEX_ImportacionETD Group by cia_codcia, IdImportacion) C ON a.cia_codcia=c.cia_codcia and a.IdImportacion=c.IdImportacion
Left Join CEX_ImportacionETD b on a.cia_codcia=b.cia_codcia and a.IdImportacion=b.IdImportacion
Where a.IdImportacion=1 -- 1345 -- 1004 --2013  -- 1966



Select cia_codcia, IdImportacion, max(NroSec) as MaxSec From CEX_ImportacionETD Group by cia_codcia, IdImportacion
Having  max(NroSec)=1
-- 1939



Select x.cia_codcia, x.IdImportacion, x.CodigoImportacion,
Max(x.FechaETD1) as FechaETD1,
Max(x.FechaETD2) as FechaETD2,
Max(x.FechaETD3) as FechaETD3,
Max(x.FechaETD4) as FechaETD4
From 
(
	Select 
	a.cia_codcia, a.IdImportacion, A.CodigoImportacion, 
	c.MaxSec,
	(Case when c.MaxSec>4 
		 then (case when b.NroSec=(c.MaxSec-4+1) then b.FechaETD else null end)
		 else (case when b.NroSec=1 then b.FechaETD else null end) 
		 end) as FechaETD1,
	(Case when c.MaxSec>4 
		 then (case when b.NroSec=(c.MaxSec-4+2) then b.FechaETD else null end)
		 else (case when b.NroSec=2 then b.FechaETD else null end) 
		 end) as FechaETD2,
	(Case when c.MaxSec>4 
		 then (case when b.NroSec=(c.MaxSec-4+3) then b.FechaETD else null end)
		 else (case when b.NroSec=3 then b.FechaETD else null end) 
		 end) as FechaETD3,
	(Case when c.MaxSec>4 
		 then (case when b.NroSec=(c.MaxSec-4+4) then b.FechaETD else null end)
		 else (case when b.NroSec=4 then b.FechaETD else null end) 
		 end) as FechaETD4
	From CEX_Importacion A
	Left Join (Select cia_codcia, IdImportacion, max(NroSec) as MaxSec From CEX_ImportacionETD Group by cia_codcia, IdImportacion) C ON a.cia_codcia=c.cia_codcia and a.IdImportacion=c.IdImportacion
	Left Join CEX_ImportacionETD b on a.cia_codcia=b.cia_codcia and a.IdImportacion=b.IdImportacion
) as X
Group by x.cia_codcia, x.IdImportacion, x.CodigoImportacion
