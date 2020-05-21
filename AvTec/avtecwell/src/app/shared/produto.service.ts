import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Produto } from './produto.model';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  formData: Produto;
  produtos: Produto[];
  readonly URL_Api = "https://webapiavtecwell.azurewebsites.net/api/v1/Produto/";

  constructor(private http : HttpClient) { }

  post(produto: Produto){
    return this.http.post(this.URL_Api, produto);
  }

  put(produto: Produto){
    return this.http.put(this.URL_Api, produto);
  }

  delete(idProduto: Number){
    return this.http.delete(this.URL_Api + idProduto);
  }

  refreshList(){
    this.http.get(this.URL_Api).toPromise().then(res => this.produtos = res as Produto[]);
  }

}
