import React, { useState } from 'react'

export default function Ex03ArrayState() {
    const[foods,setFoods]=useState(["Idly","Pongal","Coffee"])
    const addNewFood=()=>{
        const value=document.getElementById("foodInput").value;
        setFoods([...foods,value])
    }
    const removeFood=(index)=>{
        //ev.preventDefault();
        //setFoods(foods.filter((_,i)=>i!==index))
        foods.splice(index,1);
        setFoods([...foods])
    }
  return (
    <>
        <h1>List of Food Items for the Day</h1>
        <hr/>
        <ul>
            {
                foods.map((f,i)=>
                    <li key={i}>{f}<button onClick={()=>removeFood(i)}>Remove Food</button></li>
                )
            }
        </ul>
        <input type='text' placeholder='Add new Food' id='foodInput'/>
        <button onClick={addNewFood}>Add new Food</button>
    </>
  )
}
