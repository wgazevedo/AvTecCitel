import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ProdutosComponent } from './produtos/produtos.component';
import { ProdutoComponent } from './produtos/produto/produto.component';
import { ProdutoListComponent } from './produtos/produto-list/produto-list.component';
import { CategoriasComponent } from './categorias/categorias.component';
import { CategoriaComponent } from './categorias/categoria/categoria.component';
import { CategoriaListComponent } from './categorias/categoria-list/categoria-list.component';
import { CategoriaService } from './shared/categoria.service';
import { ProdutoService } from './shared/produto.service';

@NgModule({
  declarations: [
    AppComponent,
    ProdutosComponent,
    ProdutoComponent,
    ProdutoListComponent,
    CategoriasComponent,
    CategoriaComponent,
    CategoriaListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [CategoriaService, ProdutoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
