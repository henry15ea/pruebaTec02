import React, { useState, useEffect } from 'react';
import {Button } from 'react-bootstrap'; 
import { useNavigate } from 'react-router-dom';

import Card from 'react-bootstrap/Card';
import HeaderAccount from './HeaderAccount';
import NavBarApp from './navbar'; 

const Dashboard = () => {
  const navigate = useNavigate();
  const [userid, setuserid] = useState(null);
  const [nombre, setnombre] = useState(null);
  const [correo, setcorreo] = useState(null);

  useEffect(() => {
    const userid = localStorage.getItem('usuarioId');
    const nombrelbl = localStorage.getItem('nombre');
    const correolbl = localStorage.getItem('correo');

    setuserid(userid);  
    setnombre(nombrelbl);
    setcorreo(correolbl);
  }, []); 

  const manejarTransferir = () => {
    
    navigate('/transfer');
  };

  return (
    <div className='container-fluid'>
      <div>
        <NavBarApp/> 
      </div>
      <div>
        <Card>
          <Card.Header> 
              Bienvenido
            
          </Card.Header>
          <Card.Body>
            <div>
              <HeaderAccount/>
            </div>

            <div>
            <Button variant="primary" onClick={manejarTransferir}>
              Transferir
            </Button>
            </div>
          </Card.Body>
        </Card>
      </div>
    </div>
  );
}

export default Dashboard;
