import React, {useEffect, useState} from 'react';
import axios from "axios";

export default function DataContainer() {

  const [data, setData] = useState([]);
  
  useEffect(() => {
    const token = localStorage.getItem('token');
    
    axios.get(
      'http://localhost:8080/api/data',
      {headers: {'Authorization': `bearer ${token}`}}
    ).then(res => {
      if (res && res.data) {
        setData(res.data);
      }
    });
    
  }, []);
  
  return (
    <div>
      <div>
        Protected Data
      </div>
      {data.map(x => <div key={x}> {x}</div>)}    
    </div>
  )
}