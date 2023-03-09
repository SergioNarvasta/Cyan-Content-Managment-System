import React from 'react';
//import axios  from 'axios';

 class ArchivoService extends React.Component{
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
          //console.log(response.data);
        })
      }
      onChange(e) {
        this.setState({file:e.target.files[0]})
      }
    
      fileUpload = async(file)=>{
        const url = 'api/project/registro';
    
        const formData = new FormData();
        formData.append('file',file);
          console.log(file);
        await fetch(url,{
          method:'POST',
          /*headers: {
              'Content-Type':'multipart/form-data; boundary=--14737809831466499882746641449'
          },*/
          body:formData
        }).then(response=>{
          console.log(response);
        }).catch(error=>{
          console.log(error);
        })
        /*
        return  axios.post(url, formData,config)*/
      }
    
      render () {
        return (
          <div>
                <form onSubmit={this.onFormSubmit} >
            <h1>File Upload</h1>
            <input type="file" onChange={(e) => this.onChange(e)} />
            <button type="submit">Upload</button>
          </form>
          </div>
        );
      }
}

export default ArchivoService;