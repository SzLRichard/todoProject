import {useQuery,useMutation,useQueryClient, QueryClient} from '@tanstack/react-query'
import {getAllTodos,getTodoById,createTodo,deleteTodo,updateTodo} from '../api/todoApi'

export const useTodos = () => {
    const client = useQueryClient();
    const {
        data: todos,
        isLoading,
        isError,
        error,
    } = useQuery({
        queryKey: ['todos'],
        queryFn: getAllTodos
    })


    const {
        mutate: createMut,
        isPending: isAdding
    } =  useMutation({
        mutationFn: createTodo,
        onSuccess: () => {
            client.invalidateQueries({
                queryKey: ["todos"]
            })
        }
    })

    const {
        mutate: updateMut,
        isPending: isUpdating
    } =  useMutation({
        mutationFn: updateTodo,
        onSuccess: () => {
            client.invalidateQueries({
                queryKey: ["todos"]
            })
        }
    })

   const {
        mutate: deleteMut,
        isPending: isDeleting
    } =  useMutation({
        mutationFn: deleteTodo,
        onSuccess: () => {
            client.invalidateQueries({
                queryKey: ["todos"]
            })
        }
    })

return {todos,
        isLoading,
        isError,
        error,
        createMut,
        isAdding,
        updateMut,
        isUpdating,
        deleteMut,
        isDeleting
    }

}