import { Categoria } from "./categoria"
import { Usuario } from "./usuario"

export interface Lancamento{
    lancamentoId:number,
    valor:number,
    categoria?: Categoria,
    categoriaId:number
    Usuario: Usuario,
    UsuarioId: number
}