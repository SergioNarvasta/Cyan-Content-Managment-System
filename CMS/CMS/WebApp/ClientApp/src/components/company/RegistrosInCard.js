

const RegistrosInCard = ({ data }) => {
    return (
        <div><h4>Registros :</h4>
            <div className="d-flex flex-row">
                {
                    (data.length < 1) ? (
                        <div> </div>
                    ) : (
                        data.map((item) => (
                            <div key={item.company_Pk} className="me-5">
                                <div className="card d-flex flex-row">
                                    <img src={"data:image/jpg;base64," + item.file_Base64} className="card-img-top mt-5" alt="..." />
                                    <div className="card-body">
                                        <h5 className="card-title">{item.company_Nombre}</h5>
                                        <p className="card-text">{item.company_Direccion}</p>
                                        <p className="card-text">{item.company_Email}</p>
                                        <p className="card-text">{item.company_Telefono}</p>
                                        <a className="btn btn-primary">Ver Detalles</a>
                                    </div>
                                </div>
                            </div>
                        ))
                    )
                }
            </div>
        </div>
    )
}
export default RegistrosInCard;