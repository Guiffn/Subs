"use client";

import api from "@/services/api";
import { Lancamento } from "@/type/lancamento";
import {
  Container,
  Typography,
  TableContainer,
  Paper,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  TablePagination,
  Link,
  Button,
} from "@mui/material";

import { useEffect, useState } from "react";

function LancamentoListar() {
  const [lancamentos, setLancamento] = useState<Lancamento[]>([]);

  useEffect(() => {
    api
      .get<Lancamento[]>("/lacamento/listar")
      .then((resposta) => {
        setLancamento(resposta.data);
        console.table(resposta.data);
      })
      .catch((erro) => {
        console.log(erro);
      });
  }, []);

  async function Deletar(lacamentoId:number) {
    try{
        const resposta= await api.delete<Lancamento>(`lacamento/deletar/${lacamentoId}`);
        console.log("Lancamento deletado com sucesso");
    }catch(erro){
        console.log("Erro ao tentar deletar")
    }
  }


  return (
    <Container maxWidth="md" sx={{ mt: 4 }}>
      <Typography variant="h4" component="h1" gutterBottom>
        Listar Lançamentos
      </Typography>
      <TableContainer component={Paper} elevation={10}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>#</TableCell>
              <TableCell>Valor</TableCell>
              <TableCell>Categoria</TableCell>
              <TableCell>Alterar</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {lancamentos.map((lancamento) => (
              <TableRow key={lancamento.lancamentoId}>
                <TableCell>{lancamento.lancamentoId}</TableCell>
                <TableCell>{lancamento.valor}</TableCell>
                <TableCell>{lancamento.categoriaId}</TableCell>
                <TableCell>
                <Button onClick={()=> Deletar(Number(lancamento.lancamentoId))}
                    variant="contained">Excluir</Button> 
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Container>
  );
}

export default LancamentoListar;