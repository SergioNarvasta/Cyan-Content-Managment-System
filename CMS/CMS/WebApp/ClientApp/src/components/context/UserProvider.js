import { useState } from "react"
import { createContext } from "react"


export const UserContext = createContext()

const UserProvider = ({children}) => {
    const [user, setUser] = useState(window.localStorage.getItem("sesion_user"))


    const iniciarSession = (data) => {
        window.localStorage.setItem("sesion_user",JSON.stringify(data))
        setUser(JSON.stringify(data))
    }

    const cerrarSession = () => {
        window.localStorage.removeItem("sesion_user")
        setUser(null)
    }

    return (
        <UserContext.Provider value={{ user, iniciarSession, cerrarSession}}>
            {children}
        </UserContext.Provider>
        )
}

export default UserProvider