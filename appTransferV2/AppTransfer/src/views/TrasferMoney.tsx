import React, { useState, useEffect } from 'react';
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Card from 'react-bootstrap/Card';
import Alert from "react-bootstrap/Alert"; 
import { useNavigate } from 'react-router-dom';
import NavBarApp from './navbar'; 

function Transfer() {
  const navigate = useNavigate();
  const [accountCode, setAccountCode] = useState('');
  const [OwnaccountCode, setOwnaccountCode] = useState('');
  const [detailTransaction, setdetailTransaction] = useState('');
  const [amount, setAmount] = useState('');
  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(false);
  
  useEffect(() => {
    const accountCode = localStorage.getItem('CodigoCuenta');

    setOwnaccountCode(accountCode);  
  }, []); 
  
  const handleSubmit = async (e) => {
    e.preventDefault();

    // Verificar que los campos no estén vacíos
    if (!accountCode || !amount) {
      setError('Por favor, ingresa tanto el código de cuenta como el monto.');
      return;
    }

    // Llamada a la API para realizar la transferencia
    try {
      
      const response = await fetch('https://localhost:44384/TransferToAccount', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          codigoCuentaOrigen: OwnaccountCode,
          codigoCuentaDestino: accountCode,
          monto: amount,
          descripcion : detailTransaction
        }),
      });

      const result = await response.json();

      console.log(result);
      if (result.statusResponse && result.statusResponse.status) {
        setSuccess(true);
        setAccountCode("");
        setdetailTransaction("");
        setAmount("");
        setError(null); // Limpiar errores

        setTimeout(() => {
          navigate('/home');  
        }, 1200);  
        // Aquí puedes hacer algo más si la transferencia fue exitosa
      } else {
        setSuccess(false);
        setError(result.statusResponse.messageResponse || 'Hubo un error al realizar la transferencia.');
      }
    } catch (error) {
      setError('Error al realizar la transferencia. Intenta nuevamente.');
      setSuccess(false);
    }
  };

  return (
    <div className='container-fluid'>
      <div>
        <NavBarApp/>
      </div>
      <div>
        <Card>
          <Card.Header> 
          <h3>Transferir fondos</h3>
            
          </Card.Header>
          <Card.Body>
            <div>
            <Container className="mt-5">
                <div className='mb-2'> 
                  <h4><b>Desde :</b> <span>{OwnaccountCode}</span></h4>
                </div>

                <div className=''>

                <Form onSubmit={handleSubmit}>
                    <Form.Group controlId="accountCode">
                    <Form.Label>Cuenta destino</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="XXXXXXXXXX"
                        onChange={(e) => setAccountCode(e.target.value)}
                    />
                    </Form.Group>

                    <Form.Group controlId="amount">
                    <Form.Label>Monto a transferir</Form.Label>
                    <Form.Control
                        type="number"
                        placeholder="Ingresa el monto"
                        value={amount}
                        onChange={(e) => setAmount(e.target.value)}
                    />
                    </Form.Group>

                    <Form.Group controlId="accountDetails">
                    <Form.Label>Detalle</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="ej : pago de servicio"
                        onChange={(e) => setdetailTransaction(e.target.value)}
                    />
                    </Form.Group>

                    <div className='mt-2 container'>
                        {error &&
                              <Alert variant="warning" style={{ width: "42rem" }}> 
                              <Alert.Heading> 
                              {error}
                              </Alert.Heading> 
                            </Alert> 
                        }


                        {success && 
                        
                            <Alert variant="success" style={{ width: "42rem" }}> 
                            <Alert.Heading> 
                              Transferencia exitosa.
                            </Alert.Heading> 
                          </Alert> 
                        }
                    </div>

                    <Button variant="primary" type="submit" className='mt-5'>
                    Enviar transferencia
                    </Button>
                </Form>
                </div>
                
                
                </Container>
            </div>
          </Card.Body>
        </Card>
      </div>
    </div>
  );
}

export default Transfer;
