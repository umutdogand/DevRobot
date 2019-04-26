/**
 * Redux state için action tipi
 */
export type ReducerAction = {
    type: string;
    dataName: string;
    data: { } | undefined | null;
};