import { Categoria } from './categoria.model';

export class Produto {
    /** */
    constructor(
        public descricao: String,
        public sigla: String,
        public ativo: Boolean,
        public idProduto: Number,
        public idCategoria:Number,
        public categoria:Categoria,
        public sku:String,
        public marca:String,
        public modelo:String
        ) { }
}
