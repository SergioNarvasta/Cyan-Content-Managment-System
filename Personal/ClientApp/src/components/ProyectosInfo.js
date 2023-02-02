import './Proyectos.css';

const ProyectosInfo = ({data}) =>{
    return (
    <div id="List">
        { data.map ((item) =>(
          <div key={item.id} id="item"> <br></br>
            <div className="img">Imagen</div>
            <div><p>{item.name}</p></div>
            <div><p>{item.description}</p></div>
            <div><a href={item.link}>{item.link}</a></div>
          </div>
          ))
        }
    </div>
        
    )
}
export default ProyectosInfo;