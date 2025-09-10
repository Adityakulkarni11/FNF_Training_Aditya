import { useState } from 'react';
import './App.css';
import Calc from './Calc';
import Ex03ArrayState from './Ex03ArrayState';

function App() {
  let [name, setName] = useState("Guest");
  let [age, setAge] = useState(21);

  function updateName() {
    setName("Aditya");
    setAge(a => a + 1);
  }

  return (
    <>
      <div className="container mt-5">
        <div className="card p-4 shadow">
          <h1 className="text-primary">Use State Example</h1>
          <h2 className="text-secondary">Example of React App</h2>
          <hr />
          <div className="mb-3">
            <p>
              <strong>Name:</strong> {name}
              <button className="btn btn-outline-primary ms-3" onClick={updateName}>
                Change Name
              </button>
            </p>
            <p>
              <strong>Age:</strong> {age}
            </p>
          </div>
          <div className="mt-4">
            <Calc />
            <Ex03ArrayState />
          </div>
        </div>
      </div>
    </>
  );
}

export default App;
