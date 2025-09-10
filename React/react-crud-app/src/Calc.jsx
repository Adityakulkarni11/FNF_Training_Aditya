import React, { useState } from 'react'

export default function Calc() {
    const[first,setFirst]=useState(0.0)
    const[second,setSecond]=useState(0.0)
    const[operand,setOperand]=useState("Add")
    const[result,setResult]=useState(0.0)

    //Event Handler for click event
    const getResult=(ev)=>{
        switch(operand){
            case "Add":setResult(parseFloat(first)+parseFloat(second)); break;
            case "Subtract":setResult(first-second); break;
            case "Multiply":setResult(first*second); break;
            case "Divide":setResult(first/second); break;
            
        }
    }
  return (
    <>
        <h1>Calc Program</h1>
        <hr/>
        <div>
            Enter the First value: <input type='number' placeholder='Enter the First value' onChange={(e)=>setFirst(e.target.value)}/>
        
            Enter the Second value: <input type='number' placeholder='Enter the Second value' onChange={(e)=>setSecond(e.target.value)}/>
        
            Select the Option:
            <select onChange={(e)=>setOperand(e.target.value)}>
                <option>Select any option:</option>
                <option>Add</option>
                <option>Subtract</option>
                <option>Multiply</option>
                <option>Divide</option>
            </select>

            <button onClick={(ev)=>getResult(ev)}>=</button>

            <span>{result}</span>
        </div>
    </>
  )
}
