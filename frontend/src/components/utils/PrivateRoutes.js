import { Outlet, Navigate } from "react-router-dom";


const PrivateRoutes = () => {
    const isLoggedIn = localStorage.getItem("isLoggedIn");


    return (
        isLoggedIn ? <Outlet/> : <Navigate to="/login" />
    )

    
}
export default PrivateRoutes;