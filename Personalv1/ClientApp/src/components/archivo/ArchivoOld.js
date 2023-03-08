import React from 'react';
import axios  from 'axios';

 class ArchivoOld extends React.Component{
    constructor(props) {
        super(props);
        this.state ={
          file: null
        }
    
        this.onFormSubmit = this.onFormSubmit.bind(this)
        this.onChange = this.onChange.bind(this)
        this.fileUpload = this.fileUpload.bind(this)
      }
    
      onFormSubmit(e){
        //debugger;
        e.preventDefault() 
        this.fileUpload(this.state.file).then((response)=>{
          console.log(response.data);
        })
      }
      onChange(e) {
        this.setState({file:e.target.files[0]})
      }
    
      fileUpload(file){
        const url = '/api/project/RegisterFile';
    
        const formData = new FormData();
        formData.append('Archivo',file);
    
        const config = {
            headers: {
                'content-type': 'multipart/form-data'
            }
        }
        return  axios.post(url, formData,config)
      }
    
      render () {
        return (
          <div>
          <form onSubmit={this.onFormSubmit}>
            <h1>File Upload</h1>
            <input type="file" onChange={(e) => this.onChange(e)} />
            <button type="submit">Upload</button>
          </form>
          </div>
        );
      }
}

export default ArchivoOld;