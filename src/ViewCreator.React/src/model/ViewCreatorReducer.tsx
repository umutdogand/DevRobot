import { ReducerAction } from "./ReducerAction";

export const DataUpdateActionType : string = "DataUpdate";

export function dataUpdateAction(dataName : string, data : {} | undefined | null) : ReducerAction {
    return {
        type: DataUpdateActionType,
        dataName: dataName,
        data: data
    };
}

export function dataUpdateAsyncAction (dataName : string, asyncFunction : (() => Promise<{} | undefined | null>) | Function) {
    return (dispatch : any) => {
        if(asyncFunction) {
            const result = asyncFunction();
            if(result instanceof Promise) {
                result.then(function(data) {
                    dispatch(dataUpdateAction(dataName, data));
                });
            } else {
                dispatch(dataUpdateAction(dataName, result));
            }
        }
    };
}

/**
 * Redux için kullanılan reducer fonksiyonu
 * @param state State objesi
 * @param action Action objesi
 */
export default function viewCreatorReducer(state = { }, action : ReducerAction) {
    if(action.type == DataUpdateActionType) {
        const updated : any = { };
        updated[action.dataName] = action.data;
        return { ...state, ...updated };
    }
    return  state;
}