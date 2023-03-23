import { useState } from "react"
import Swal from 'sweetalert2'

const Login = () => {
    const [_correo, set_Correo] = useState("")
    const [_clave, set_Clave] = useState("")

    const handleSubmit = async (event) => {
        event.preventDefault();
        let request = {
            correo: _correo,
            clave: _clave
        }
        const response = await fetch("api/session/Login", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(request)
        });
        if (response.ok) {
            const data = await response.json();
            if (data.user_Pk == "") {
                Swal.fire(
                    'Opps!',
                    'No se encontro el usuario',
                    'error'
                )
            } else {
                console.log(data);
                window.localStorage.setItem("sesion_user", JSON.stringify(data))
                Swal.fire(
                    'Credenciales validas!',
                    'Bienvenido',
                    'success'
                )
                window.location = "/";
            }
        } else {
            Swal.fire(
                'No se pudo iniciar session!',
                'verifique credenciales',
                'error'
            )
        }
    }

    return (
        <div className="container">

            <div className="row justify-content-center">

                <div className="col-xl-10 col-lg-12 col-md-9">

                    <div className="card o-hidden border-0 shadow-lg my-5">
                        <div className="card-body p-0">

                            <div className="row">
                                <div className="col-lg-6 d-none d-lg-block bg-login-image"></div>
                                <div className="col-lg-6">
                                    <div className="p-5">
                                        <div className="text-center">
                                            <h1 className="h4 text-gray-900 mb-4">Bienvenido</h1>
                                        </div>
                                        <form className="user" onSubmit={handleSubmit}>
                                            <div className="form-group">
                                                <input type="email" className="form-control form-control-user" aria-describedby="emailHelp" placeholder="Correo"
                                                    value={_correo}
                                                    onChange={(e) => set_Correo(e.target.value)}
                                                />
                                            </div> <br></br>
                                            <div className="form-group">
                                                <input type="password" className="form-control form-control-user" placeholder="Contraseña"
                                                    value={_clave}
                                                    onChange={(e) => set_Clave(e.target.value)}
                                                />
                                            </div><br></br>
                                            <button type="submit" className="btn btn-primary btn-user btn-block"> Ingresar </button>

                                        </form>
                                        <hr></hr>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

            </div>

        </div>
    )
}

export default Login