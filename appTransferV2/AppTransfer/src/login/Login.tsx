import React, { useState } from 'react';
import { Link } from "react-router-dom";
import { useNavigate } from 'react-router-dom';

const Login = () => {
  const navigate = useNavigate();
  // Definir el estado para el formulario
  const [nombreUsuario, setnombreUsuario] = useState('');
  const [contrasena, setcontrasena] = useState('');
  const [error, setError] = useState('');
  const [successMessage, setSuccessMessage] = useState('');

  // Manejar el envío del formulario
  const handleSubmit = async (e) => {
    e.preventDefault();
  
    if (!nombreUsuario || !contrasena) {
      setError('Por favor, ingresa un correo y una contraseña.');
      setSuccessMessage('');
    } else {
      setError('');
      setSuccessMessage('');
      
      // Definir los datos a enviar
      const data = { nombreUsuario, contrasena };
      
      // Hacer una solicitud POST a la API
      try {
        const response = await fetch('https://localhost:44384/api/Session', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(data),
        });

        const result = await response.json();

        // Verificar si la respuesta es exitosa
        if (result.statusResponse && result.statusResponse.status) {
          console.log('Respuesta de la API:', result);
          const userData = result.data;
        
          // Mostrar mensaje de inicio de sesión exitoso
          setSuccessMessage(`¡Bienvenido, ${userData.nombreCompleto}!`);
          // Guardar los datos en localStorage
          localStorage.setItem('nombre', userData.nombreCompleto);
          localStorage.setItem('correo', userData.correo);
          localStorage.setItem('usuarioId', userData.usuarioId);
        
          // Espera para garantizar que el localStorage se haya actualizado
          setTimeout(() => {
            navigate('/home');  
          }, 600);  
        
        } else {
          console.error('Error en la autenticación:', result.statusResponse.messageResponse);
          setError(result.statusResponse.messageResponse || 'No se pudo autenticar. Intenta nuevamente.');
        }
      } catch (error) {
        console.error('Error al autenticar:', error);
        setError('Hubo un error al intentar autenticarte.');
      }
    }
  };

  return (
    <div className="container-fluid d-flex justify-content-center align-items-center" style={{ minHeight: '100vh' }}>
      <div className="card" style={{ width: '100%', maxWidth: '400px' }}>
        <div className="card-body">
          <h2 className="card-title text-center mb-4">Iniciar sesión</h2>
          <form onSubmit={handleSubmit}>
            <div className="mb-3">
              <label htmlFor="nombreUsuario" className="form-label">Nombre de usuario</label>
              <input
                type="text"
                id="nombreUsuario"
                className="form-control"
                value={nombreUsuario}
                onChange={(e) => setnombreUsuario(e.target.value)}
                required
              />
            </div>
            <div className="mb-3">
              <label htmlFor="contrasena" className="form-label">Contraseña</label>
              <input
                type="password" // Cambia el tipo a 'password' para ocultar la entrada
                id="contrasena"
                className="form-control"
                value={contrasena}
                onChange={(e) => setcontrasena(e.target.value)}
                required
              />
            </div>
            <div>
      
    </div>
            {error && <p className="text-danger">{error}</p>}
            {successMessage && <p className="text-success">{successMessage}</p>}
            <button type="submit" className="btn btn-primary w-100">Iniciar sesión</button>
          </form>
        </div>
      </div>
    </div>
  );
};

export default Login;