import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Categoria } from './categoria.model';

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {

  formData: Categoria;
  categorias: Categoria[];
  readonly URL_Api = "https://webapiavtecwell.azurewebsites.net/api/v1/Categoria/";

  constructor(private http : HttpClient) { }

  post(categoria: Categoria){
    return this.http.post(this.URL_Api, categoria);
  }

  put(categoria: Categoria){
    return this.http.put(this.URL_Api, categoria);
  }

  delete(idCategoria: Number){
    console.log(this.URL_Api + idCategoria);
    return this.http.delete(this.URL_Api + idCategoria);
  }

  refreshList(){
    this.http.get(this.URL_Api).toPromise().then(res => this.categorias = res as Categoria[]);
  }

}
