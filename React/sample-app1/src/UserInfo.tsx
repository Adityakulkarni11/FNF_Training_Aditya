//import {PropTypes} from 'prop-types';
export default function UserInfo(props:any) {
    const name=props.name;
    const age=props.age;
    const isStudent=props.isStudent;
  return (
    <div className='card'>
        <h2>User Info</h2>
        <hr/>
        <p>Name: {name}</p>
        <p>Age: {age}</p>
        <p>Is Student: {isStudent ? "Yes" : "Not a Student"}</p>
    </div>
  )
}
