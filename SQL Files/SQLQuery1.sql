Use EQUILIBRA_V17
select*from CEX_EstadoPago
---TioConfirmacion ,PaisOrigen ,AlmacenDestino
Select  
     a.FechaETA         ,      q.EstadoPago         ,       a.CodigoImportacion  ,       a.FechaIngAlm,
	 a.OCompraSG        ,      a.TotalUSD           ,       C.ProveedorCEX       ,       B.ProductoCEX,
	 a.CantidadTM       ,      a.CantidadCNT        ,       a.NroDAM             ,       a.FechaDAMLevante,
	 a.FechaVB          ,      v.PAI_NOMCOR as Pais ,       a.NaveDestino        ,       a.BL,
	 l.Naviera          ,      g.PuertoDestino      ,       a.Contrato           ,       v.PAI_NOMCOR AS PaisOrigen,
	 a.Almacen          ,      y.ConfirmaFecha      
	From CEX_Importacion A
	Left Join Cex_ProductoCEX B on A.IdProductoCEX=B.IdProductoCEX
	Left Join Cex_ProveedorCEX C on A.IdProveedorCEX=C.IdProveedorCEX
	Left Join Cex_Seguimiento D on a.IdSeguimiento=d.IdSeguimiento
	Left Join Cex_TipoCarga E on a.IdTipoCarga=e.IdTipoCarga
	Left Join Cex_PuertoOrigen F on a.IdPuertoOrigen=f.IdPuertoOrigen
	Left Join Cex_PuertoDestino G on a.IdPuertoDestino=G.IdPuertoDestino
	Left Join CEX_Direccionamiento H on a.IdDireccionamiento = h.IdDireccionamiento
	left join CEX_CanalCEX I on a.IdCanalCEX=i.IdCanalCex
	left join CEX_Incoterm J on a.IdIncoterm=j.IdIncoterm
	left join CEX_EmisionBL K on a.IdEmisionBL=k.IdEmisionBL
	left join CEX_Naviera L on a.IdNaviera=l.IdNaviera
	left join CEX_Regimen M on a.IdRegimen=m.IdRegimen
	left join CEX_PresentacionCEX N on a.IdPresentacion=N.IdPresentacionCEX
	left join CEX_PlazoPago O on a.IdPlazoPago=o.IdPlazoPago
	left join CEX_DiasPlazo P on a.IdDiasPlazo=p.IdDiasPlazo
	left join CEX_EstadoPago Q on a.IdEstadoPago=q.IdEstadoPago
	Left Join CEX_TipoCarga02 R on a.IdTipoCarga02=r.IdTipoCarga02
	left join PRODUCTOS_PRD prd on a.prd_codepk=prd.prd_codepk
    Left Join CEX_ClasificacionMitsui S on b.IDClasificacionMitsui=s.IdClasificacionMitsui
	Left Join CEX_Marca T on a.IdMarca=t.IdMarca
	Left Join CEX_TerminoFletamiento U on a.IdFletamiento=U.IdFletamiento
	Left Join pais_pai V on a.pai_codpai=v.PAI_CODPAI
	Left Join CEX_TerminalMar W on a.IdTerminalMar=w.IdTerminalMar
	Left Join CEX_AlmacenDestino X on a.IdAlmacenDestino=x.IdAlmacenDestino
	left join CEX_ConfirmaFecha Y on y.IdConfirmaFecha = a.IdConfirmaAlm 
	
	---------------------------------------------------------0011 0579 0202936376
	