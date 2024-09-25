import HeaderLogo from './Header/HeaderLogo'
import SearchBar from './Header/SearchBar'

export default function Header(){
    return(
        <>
            <nav style={{backgroundColor: 'rgb(3, 152, 252)', paddingBottom: '60px'}}>
                <HeaderLogo/>
                <SearchBar/>
            </nav>
        </>
    )
}