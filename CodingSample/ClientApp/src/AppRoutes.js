import { LoansScreen } from "./screens/LoansScreen";
import { ImportLoansScreen } from "./screens/ImportLoansScreen";
import { Home } from "./components/Home";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/loans',
        element: <LoansScreen />
    },
    {
        path: '/importloans',
        element: <ImportLoansScreen />
    }
];

export default AppRoutes;
