"use client";

import React, { useEffect, useState } from "react";
import { useRouter, useParams } from "next/navigation"; // caso use Next.js 13+
import {
  Container,
  Typography,
  TextField,
  Button,
  Box,
  Alert,
  MenuItem,
} from "@mui/material";
import api from "@/services/api";
import { Categoria } from "@/type/categoria";
import { Lancamento } from "@/type/lancamento";


export default function AlterarLancamento() {
  const router = useRouter();
  const { lancamentoId } = useParams(); // Pega o id da url

  const [lancamento, setLancamento] = useState<Lancamento | null>(null);
  const [categorias, setCategorias] = useState<Categoria[]>([]);
  const [valor, setValor] = useState("");
  const [categoriaId, setCategoriaId] = useState("");
  const [erro, setErro] = useState("");
  const [sucesso, setSucesso] = useState("");

  useEffect(() => {
    // Buscar lançamento para preencher o formulário
    api
      .get<Lancamento>(`/lancamento/${lancamentoId}`)
      .then((res) => {
        setLancamento(res.data);
        setValor(res.data.valor.toString());
        setCategoriaId(res.data.CategoriaId.toString());
      })
      .catch(() => setErro("Erro ao carregar o lançamento."));

    // Buscar categorias para select
    api
      .get<Categoria[]>("/categoria/listar")
      .then((res) => setCategorias(res.data))
      .catch(() => setErro("Erro ao carregar categorias."));
  }, [lancamentoId]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setErro("");
    setSucesso("");

    try {
      await api.put(`/lancamento/alterar/${lancamentoId}`, {
        valor: parseFloat(valor),
        categoriaId: parseInt(categoriaId),
      });
      setSucesso("Lançamento alterado com sucesso!");
      // opcional: redirecionar ou atualizar página
      // router.push("/lancamento/listar");
    } catch (error: any) {
      setErro(
        error.response?.data || "Erro ao alterar o lançamento, tente novamente."
      );
    }
  };

  if (!lancamento) return <Typography>Carregando...</Typography>;

  return (
    <Container maxWidth="sm" sx={{ mt: 4 }}>
      <Typography variant="h4" gutterBottom>
        Alterar Lançamento #{lancamento.lancamentoId}
      </Typography>

      {erro && <Alert severity="error" sx={{ mb: 2 }}>{erro}</Alert>}
      {sucesso && <Alert severity="success" sx={{ mb: 2 }}>{sucesso}</Alert>}

      <Box component="form" onSubmit={handleSubmit} noValidate>
        <TextField
          label="Valor"
          type="number"
          fullWidth
          margin="normal"
          value={valor}
          onChange={(e) => setValor(e.target.value)}
          required
        />

        <TextField
          select
          label="Categoria"
          fullWidth
          margin="normal"
          value={categoriaId}
          onChange={(e) => setCategoriaId(e.target.value)}
          required
        >
          {categorias.map((cat) => (
            <MenuItem key={cat.categoriaId} value={cat.categoriaId.toString()}>
              {cat.tipo}
            </MenuItem>
          ))}
        </TextField>

        <Button type="submit" variant="contained" color="primary" sx={{ mt: 2 }}>
          Alterar
        </Button>
      </Box>
    </Container>
  );
}
