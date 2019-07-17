import React from 'react';
import './index.css';

const DisplayError =({error})=>(
  <div className="well error">

     {error.detail}
  </div>
    
);

export default DisplayError;    