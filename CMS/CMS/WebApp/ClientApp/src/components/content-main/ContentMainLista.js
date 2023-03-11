
import { useEffect, useState } from "react";

const SliderMainLista = () => {

    const [contentmain, setContentmain] = useState([]);

    const Listar = async () => {
        const response = await fetch("/api/content/lista");
        if (response.ok) {
            const data = await response.json();
            setContentmain(data);
        } else {
            console.log("Error al listar (/api/content/lista)")
        }
    }
    useEffect(() => {
        Listar()
    }, [])
    return (
        <div>
            <h5>Lista Content Main</h5>
            <div className="d-flex flex-row">
                {contentmain.map((item) => (
                    <div key={item.contentMain_Pk}>
                        <p>{item.contentMain_Titulo}</p>
                    </div>
                ))
                }
            </div>
        </div>
    
    )

}
export default SliderMainLista;
