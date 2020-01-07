import React from 'react';
import logo from './logo.svg';
import './App.css';
import { ToDo } from './pages/to-do';

const App: React.FC = () => {
  return (
    <div className="App">
      <ToDo></ToDo>
    </div>
  );
}

export default App;
