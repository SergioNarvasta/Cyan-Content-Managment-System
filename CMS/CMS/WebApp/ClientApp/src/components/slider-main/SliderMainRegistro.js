import { useState, useEffect } from "react";
import { Form, FormGroup, Input, Button } from "reactstrap";
import SliderMainListado from './SliderMainListado';
import './Style.css';

const modelo = {
    sliderMain_Pk: "",
    sliderMain_Titulo: "",
    sliderMain_Descripcion: "",
    sliderMain_Estado: 0,
    sliderMain_UsuarioPk: "",
    sliderMain_Slider: "",
    file_NombreF: "",
    file_Base64F: "",
    file_TamanioF: "",
    file_NombreS: "",
    file_Base64S: "",
    file_TamanioS: "",
    file_NombreT: "",
    file_Base64T: "",
    file_TamanioT: "",
    audit_UsuCre: "",
    audit_FecCre: "",
    audit_UsuAct: "",
    audit_FecAct: ""
}
const modelo_user = {
    user_Pk: "",
    user_Nombre: "",
    user_Direccion: "",
    user_Telefono: 0,
    user_Email: "",
    user_Token: "",
    user_Estado: 0,
    plan_Pk: "",
    rol_Pk: "",
    audit_UsuCre: "",
    audit_FecCre: "",
    audit_UsuAct: "",
    audit_FecAct: ""
}
const SliderMainRegistro = () => {
    const [sliderMainCreate, setsliderMainCreate] = useState(modelo);
    const [user] = useState(window.localStorage.getItem("sesion_user"))
    const [dataUser, setDataUser] = useState(modelo_user)

    useEffect(() => {
        let dt = JSON.parse(user)
        setDataUser(dt)
    }, [])

    const actualizaDato = (e) => {
        setsliderMainCreate(
            {
                ...sliderMainCreate,
                [e.target.name]: e.target.value
            }
        )
    }
    const enviarDatos = () => {
        sliderMainCreate.audit_UsuCre = dataUser.user_Nombre
        registrar(sliderMainCreate)
    }
    const registrar = async (sliderMainCreate) => {
        const response = await fetch("api/slidermain/registro", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(sliderMainCreate)
        })
        if (response.ok) {
            window.location.reload();
        }
    }
    async function cargarArchivo(e) {
        var cant = e.target.files.length;
        for (var index = 0; index < cant; index++) {
            let nombre = e.target.files[index].name;
            if (nombre.length > 1) {
                let tamanio = e.target.files[index].size.toString();
                if (tamanio > 1) {
                    if (tamanio < 5120000) {
                        let next = nombre.lastIndexOf('.');
                        let extension = nombre.substring(next + 1);
                        if (extension === "jpg" || extension === "png" || extension === "jpeg" || extension === "gif") {
                            console.log('Convirtiendo blob -> ' + index);
                            const myBlob = e.target.files[index];
                            const myB64 = await blobToBase64(myBlob);
                            switch (index) {
                                case 0:
                                    sliderMainCreate.file_Base64F = myB64;
                                    sliderMainCreate.file_NombreF = nombre;
                                    sliderMainCreate.file_TamanioF = tamanio;
                                    break;
                                case 1:
                                    sliderMainCreate.file_Base64S = myB64;
                                    sliderMainCreate.file_NombreS = nombre;
                                    sliderMainCreate.file_TamanioS = tamanio;
                                case 2:
                                    sliderMainCreate.file_Base64T = myB64;
                                    sliderMainCreate.file_NombreT = nombre;
                                    sliderMainCreate.file_TamanioT = tamanio;
                            }
                        } else { alert("Archivo Invalido!. No tiene formato de imagen solicitado"); }
                    } else { alert("Archivo Invalido!. Supera el limite 5MB"); }
                } else { alert("Archivo Invalido!. No tiene contenido"); }
            } else { alert("Archivo Invalido!. No tiene nombre"); }

        }
        console.log("Se leyeron :" + cant + " archivos");
        console.log(sliderMainCreate);
    }
    const blobToBase64 = (blob) => {
        return new Promise((resolve, reject) => {
            const reader = new FileReader();
            reader.readAsDataURL(blob);
            reader.onloadend = () => {
                resolve(reader.result.split(',')[1]);
            };
        });
    }
    const ocultarForm = () => {
        document.getElementById('form_registro').style.display = 'none';
        document.getElementById('group_filtro').style.display = 'block';
    }
    const mostrarForm = () => {
        document.getElementById('group_filtro').style.display = 'none';
        document.getElementById('form_registro').style.display = 'block';
    }
    return (
        <div id="comp_slidermain">
            <h3 >Gestion de SliderMain</h3>
            <Form id="form_registro">
                <p className="text-danger">El usuario ve sus SliderMain, puede editar,eliminar,agregar y debe seleccionar un slider a mostrar</p>
                <p className="text-danger">El admin ve todas los registros asociados a usuarios y compañias, puede editar,eliminar,desactivar</p> <br />
                <FormGroup className="d-flex flex-row ">
                    <label className="me-2" >Titulo</label>
                    <Input id="txt_titulo" name="sliderMain_Titulo" onChange={(e) => actualizaDato(e)}
                        value={sliderMainCreate.sliderMain_Titulo}></Input>
                </FormGroup>
                <div className="d-flex flex-row">
                    <FormGroup className="d-flex flex-row" id="group_desc">
                        <label className="me-2">Descripcion</label>
                        <textarea id="txa_desc" name="sliderMain_Descripcion" onChange={(e) => actualizaDato(e)}
                            value={sliderMainCreate.sliderMain_Descripcion}></textarea>
                    </FormGroup>
                    <FormGroup className="d-flex flex-row ms-1" id="group_tipo">
                        <label className="me-1">Tipo</label>
                        <select id="cbo_tipo" onChange={(e) => actualizaDato(e)} >
                            <option value="1">Carousel Automatico</option>
                            <option value="0">Banner Estatico</option>
                        </select>
                    </FormGroup>
                </div>
                <div className="d-flex flex-row ">
                    <FormGroup className="d-flex flex-row">
                        <label className="me-5">Archivos</label>
                        <input type="file" multiple accept=".jpg,.png,.gif" onChange={(e) => cargarArchivo(e)} />
                    </FormGroup>
                    <FormGroup >
                        <Button id="btnRegistrar" onClick={enviarDatos} className="btn btn-success ms-5">Registrar</Button>
                        <Button id="btnOcultar" onClick={ocultarForm} className="btn btn-danger ms-5">Ocultar</Button>
                    </FormGroup>
                </div>
                <div id="container_files">
                    <div >
                        <FormGroup className="d-flex flex-row">
                            <label >Base 64 1</label>
                            <Input id="file_Base640" name="file_Base64F" onChange={(e) => actualizaDato(e)} value={sliderMainCreate.file_Base64F}></Input>
                        </FormGroup>
                        <FormGroup className="d-flex flex-row">
                            <label>Nombre Archivo 1</label>
                            <Input id="file_Nombre0" name="file_NombreF" onChange={(e) => actualizaDato(e)} value={sliderMainCreate.file_NombreF}></Input>
                        </FormGroup>
                        <FormGroup className="d-flex flex-row">
                            <label>Tamaño Archivo 1</label>
                            <Input id="file_Tamanio0" name="file_TamanioF" onChange={(e) => actualizaDato(e)} value={sliderMainCreate.file_TamanioF}></Input>
                        </FormGroup>
                    </div>
                    <div>
                        <FormGroup className="d-flex flex-row">
                            <label>Base 64 2</label>
                            <Input id="file_Base641" name="file_Base64S" onChange={(e) => actualizaDato(e)} value={sliderMainCreate.file_Base64S}></Input>
                        </FormGroup>
                        <FormGroup className="d-flex flex-row">
                            <label>Nombre Archivo 2</label>
                            <Input id="file_Nombre1" name="file_NombreS" onChange={(e) => actualizaDato(e)} value={sliderMainCreate.file_NombreS}></Input>
                        </FormGroup>
                        <FormGroup className="d-flex flex-row">
                            <label>Tamaño Archivo 2</label>
                            <Input id="file_Tamanio1" name="file_TamanioS" onChange={(e) => actualizaDato(e)} value={sliderMainCreate.file_TamanioS}></Input>
                        </FormGroup>
                    </div>
                    <div>
                        <FormGroup className="d-flex flex-row">
                            <label>Base 64 3</label>
                            <Input id="file_Base642" name="file_Base64T" onChange={(e) => actualizaDato(e)} value={sliderMainCreate.file_Base64T}></Input>
                        </FormGroup>
                        <FormGroup className="d-flex flex-row">
                            <label>Nombre Archivo 3</label>
                            <Input id="file_Nombre2" name="file_NombreT" onChange={(e) => actualizaDato(e)} value={sliderMainCreate.file_NombreT}></Input>
                        </FormGroup>
                        <FormGroup className="d-flex flex-row">
                            <label>Tamaño Archivo 3</label>
                            <Input id="file_Tamanio2" name="file_TamanioT" onChange={(e) => actualizaDato(e)} value={sliderMainCreate.file_TamanioT}></Input>
                        </FormGroup>
                    </div>
                </div>
            </Form>
            <div id="group_filtro" className="d-flex flex-row">
                <FormGroup className="d-flex flex-row busqueda" >
                    <label className="me-2">Busqueda</label>
                    <Input id="txtBusqueda" ></Input>
                </FormGroup>
                <FormGroup >
                    <Button id="btnMostrar" onClick={mostrarForm} className="btn btn-warning ms-5">Nuevo</Button>
                </FormGroup>
            </div>
            <br></br>
            <SliderMainListado />
        </div>
    )
}

export default SliderMainRegistro;