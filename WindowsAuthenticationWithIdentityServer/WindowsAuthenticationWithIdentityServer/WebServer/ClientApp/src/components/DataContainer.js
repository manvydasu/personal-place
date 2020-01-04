import React, {useEffect, useState} from 'react';
import axios from "axios";

import Table from './Table';

export default function DataContainer() {

  const [data, setData] = useState([]);
  
  useEffect(() => {
    const token = localStorage.getItem('token');
    
    axios.get(
      'http://localhost:8000/api/data',
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
      <Table data={data} />
    </div>
  )
}