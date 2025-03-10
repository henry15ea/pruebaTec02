import React, { useState, useEffect } from 'react';
import { Card } from 'react-bootstrap'; 

const HeaderAccount = () => {
  const [userid, setuserid] = useState(null);
  const [nombre, setnombre] = useState(null);
  const [correo, setcorreo] = useState(null);
  const [codCuenta, setcodCuenta] = useState(null);
  const [balance, setBalance] = useState(null); // Estado para el balance
  const [accountName, setAccountName] = useState("Cuenta Principal"); // Estado para el nombre de la cuenta
  const [loading, setLoading] = useState(true); // Estado para controlar el estado de carga
  const [error, setError] = useState(null); // Estado para manejar errores

  useEffect(() => {
    // Obtener datos del localStorage de los valores que trae la api y se setearon en login
    const userid = localStorage.getItem('usuarioId');
    const nombrelbl = localStorage.getItem('nombre');
    const correolbl = localStorage.getItem('correo');

    setuserid(userid);
    setnombre(nombrelbl);
    setcorreo(correolbl);

    const fetchData = async () => {
      try {
        const token = localStorage.getItem('authToken');  // Obtener el token desde el localStorage
        const accountCode = ""; // Aquí podrías agregar el código de cuenta si es necesario

        const response = await fetch('https://localhost:44384/GetAccountBalance', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            token: "", // Usar el token real
            accountCode: "", // Agregar código de cuenta si es necesario
            id: userid, // Usar el ID del usuario desde el localStorage
          }),
        });

        const result = await response.json();
        const userData = result.data;
        // Verifica si la respuesta es correcta y actualiza el estado
        if (result.statusResponse && result.statusResponse.status) {
          setBalance(userData.saldo); // Actualiza el balance
          setAccountName(userData.tipocuenta);
          setcodCuenta(userData.codigocuenta);
          localStorage.setItem('CodigoCuenta', userData.codigocuenta);

        } else {
          setError("Error al cargar el balance.");
        }
      } catch (error) {
        setError("Hubo un error al obtener los datos.");
      } finally {
        setLoading(false); // Deja de cargar una vez que la solicitud haya terminado
      }
    };

    if (userid) {
      fetchData();
    }
  }, [userid]); // Este useEffect se ejecuta cuando el componente se monta o cuando cambia el usuarioId

  // Mostrar un mensaje mientras se carga o si hay un error
  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>Error: {error}</div>;
  }

  return (
    <div className="d-flex justify-content-center" style={{ margin: '20px' }}>
      <Card style={{ width: '18rem', padding: '20px', borderRadius: '10px' }} bg='primary' text='light'>
        <Card.Body>
          <Card.Title><span style={{ fontWeight: 'bold' }}>
              {nombre ? ` ${nombre}` : 'No disponible'}
            </span></Card.Title>
          <Card.Text>
            <strong>Cuenta:</strong> {codCuenta}
          </Card.Text>
          <Card.Text>
            <strong>Tipo Cuenta:</strong> {accountName}
          </Card.Text>
          <Card.Text>
            <strong>Saldo:</strong> {balance !== null ? `$${balance}` : 'No disponible'}
          </Card.Text>
        </Card.Body>
      </Card>
    </div>
  );
}

export default HeaderAccount;
