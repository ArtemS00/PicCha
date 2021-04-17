import './App.css';
import Navbar from './navbar'
import RegisterPage from './page/RegisterPage';
import AddChallangePage from './page/AddChallengePage'
function App() {
  return (
    <div>
     <Navbar/>
     {/* <RegisterPage/> */}
     <AddChallangePage/>
    </div>
  );
}

export default App;
