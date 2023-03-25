import { useState } from "react";
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
const modelo_files ={
    file_NombreF: "",
    file_Base64F: "",
    file_TamanioF: "",
    file_NombreS: "",
    file_Base64S: "",
    file_TamanioS: "",
    file_NombreT: "",
    file_Base64T: "",
    file_TamanioT: "",
}

const SliderMainRegistro = () => {

    const [sliderMainCreate, setsliderMainCreate] = useState(modelo);
    const [files, setfiles] = useState(modelo);
    const actualizaDato = (e) => {
        console.log(e.target.name + " : " + e.target.value);
        setsliderMainCreate(
            {
                ...sliderMainCreate,
                [e.target.name]: e.target.value
            }
        )
    }
    const enviarDatos = () => {
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
                            document.getElementById('file_Base64' + index).value = myB64;
                            document.getElementById('file_Nombre' + index).value = nombre;
                            document.getElementById('file_Tamanio' + index).value = tamanio;
                            console.log("nombre : " + nombre + " tamaño : " + tamanio);
                            console.log(myB64);
                        } else { alert("Archivo Invalido!. No tiene formato de imagen solicitado"); }
                    } else { alert("Archivo Invalido!. Supera el limite 5MB"); }
                } else { alert("Archivo Invalido!. No tiene contenido"); }
            } else { alert("Archivo Invalido!. No tiene nombre"); }

        }
        console.log("Se leyeron :" + cant + " archivos");
    }
    const blobToBase64 = (blob) => {
        return new Promise((resolve, reject) => {
            const reader = new FileReader();
            reader.readAsDataURL(blob);
            reader.onloadend = () => {
                resolve(reader.result.split(',')[1]);
            };
        });
    };

    return (
        <div id="comp_slidermain">
            <Form id="form-registro"><br /><br />
                <h2 className="text-center">Gestion de SliderMain</h2> <br />               
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
            <br></br>

            <SliderMainListado />
        </div>
    )
}

export default SliderMainRegistro;