import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';

import Login from './login/Login';  
import Dashboard from './views/dashboard';
import Transfer from './views/TrasferMoney';


function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/home" element={<Dashboard />} />
        <Route path="/transfer" element={<Transfer />} />
      </Routes>
    </Router>
  );
}

export default App;