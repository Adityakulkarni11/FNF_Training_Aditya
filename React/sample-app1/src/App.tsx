import Footer from "./Footer"
import Header from "./Header"
import Profile from "./Profile"
import UserInfo from "./UserInfo"

function App() {
  return (
    <div>
      <h1>Welcome to React</h1>
      <hr/>
      <Header></Header>
      <Profile/>
      <UserInfo name="Aditya" age={21} isStudent={false}></UserInfo>
      <Footer></Footer>
    </div>
  )
}
export default App
