SELECT	  
	Q.EstadoPago,
	ISNULL(a.CodAnt,' ')AS MF ,                         
	ISNULL(B.ProductoCEX,' ')AS Producto,                   
	ISNULL(C.ProveedorCEX,' ')AS Proveedor    ,
	ISNULL(a.Factura,'')AS Factura,                                           
	ISNULL(O.PlazoPago,'')AS PlazoPago,                     
	ISNULL(P.DiasPlazo,'')AS DiasPlazo,
	ISNULL(YEAR(a.FechaVenFactura),'')AS AñoVctoFact,
	ISNULL(DATENAME(MONTH,a.FechaVenFactura),'')AS MesTexto,
	ISNULL(DATEPART(MONTH,a.FechaVenFactura),'')AS MesVctoFact,
	ISNULL(DATEPART(WEEK,a.FechaVenFactura),'')AS SemVctoFact,
	ISNULL(a.FechaVenFactura,'')AS FechaVctoFact,
	a.CantidadTM,
	a.PrecioUSDTM,
	ISNULL(a.CantidadTM*a.PrecioUSDTM,0)AS Total,
	ISNULL(maETD.FechaETD,'')AS EmbProg, 
	Isnull((Select top 1 DetalleLog From CEX_LogImportacion Where cia_codcia=a.cia_codcia and IdImportacion=a.IdImportacion Order by IdLogImp Desc),'') as Coment,
	ISNULL(a.FechaIngAlm,'')AS FechaEnvInv,         
	Space(5)AS FirmaResp,
	Space(5)AS FechaFirma	
	From CEX_Importacion A
	Left Join Cex_ProductoCEX B on A.IdProductoCEX=B.IdProductoCEX
	Left Join Cex_ProveedorCEX C on A.IdProveedorCEX=C.IdProveedorCEX
	Left Join Cex_Seguimiento D on a.IdSeguimiento=d.IdSeguimiento
	Left Join Cex_TipoCarga E on a.IdTipoCarga=e.IdTipoCarga
	Left Join Cex_PuertoOrigen F on a.IdPuertoOrigen=f.IdPuertoOrigen
	Left Join Cex_PuertoDestino G on a.IdPuertoDestino=G.IdPuertoDestino
	left join CEX_PresentacionCEX N on a.IdPresentacion=N.IdPresentacionCEX
	left join CEX_PlazoPago O on a.IdPlazoPago=o.IdPlazoPago
	left join CEX_DiasPlazo P on a.IdDiasPlazo=p.IdDiasPlazo
	left join CEX_EstadoPago Q on a.IdEstadoPago=q.IdEstadoPago
	left join PRODUCTOS_PRD R on a.prd_codepk=R.prd_codepk
	Left Join (Select cia_codcia, idimportacion, max(nrosec) as maxsec from CEX_ImportacionETD group by cia_codcia, idimportacion ) dETD on (a.cia_codcia=dETD.cia_codcia and a.IdImportacion=dETD.IdImportacion)
	Left Join CEX_ImportacionETD as maETD on a.cia_codcia=maETD.cia_codcia and a.IdImportacion=maETD.IdImportacion and dETD.maxsec=maETD.NroSec
	where año=2022 and (Q.EstadoPago='PENDIENTE')
	