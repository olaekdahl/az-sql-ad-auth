import {useEffect, useState } from 'react';

function Weather() {
  const [data, setData] = useState([]);
 useEffect(()=>{
  fetch('http://localhost:5139/adw')
    .then(response => response.json())
    .then(setData).then(console.log(data));
 }, []);
  
 return (
   <div className='App-header'>
      {data.map(person => 
       <div key={person.customerId}>{person.firstName} {person.lastName}</div>)}
    </div>
  );
}

export default Weather;