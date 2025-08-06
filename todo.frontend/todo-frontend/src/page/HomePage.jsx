import AddTodoForm from "../components/AddTodoForm";
import TodoList from "../components/TodoList";

export default function HomePage () {


    return (
        <div className="container">
            <main>
                <AddTodoForm />
                <TodoList>
                </TodoList>
            </main>
        </div>
    )

}