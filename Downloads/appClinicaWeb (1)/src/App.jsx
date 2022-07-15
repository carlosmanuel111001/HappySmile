import { useState } from 'react'
import logo from './logo.svg'
import './App.css'

import {
  BrowserRouter as Router,
  Routes,
  Route
} from "react-router-dom";

import { Home } from './pages/index';
import { UsuarioPage } from './pages/usuario.page';
import { PacientePage } from './pages/paciente.page';
import { CitaPage } from './pages/cita.page';
import { EspecialistaPage } from './pages/especialista.page';
import { DiagnosticoPage } from './pages/diagnostico.page';
import { LoginPage } from './pages/login.page';
import { UsuarioContextWrapper } from './contexts/usuario';

function App() {
  return (
    <UsuarioContextWrapper>
      <Router>
        <Routes>
          <Route exact path="/" element={<Home />} />
          <Route exact path="/usuario" element={<UsuarioPage />} />
          <Route exact path="/paciente" element={<PacientePage />} />
          <Route exact path="/cita" element={<CitaPage />} />
          <Route exact path="/diagnostico" element={<DiagnosticoPage />} />
          <Route exact path="/especialista" element={<EspecialistaPage />} />
          <Route exact path="/login" element={<LoginPage />} />
        </Routes>
      </Router>
    </UsuarioContextWrapper>
  );
};

export default App
