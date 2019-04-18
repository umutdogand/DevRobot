
// Ajax sorguları sonucunu resolve edilebilmesi için kullanılan base sınıf
// Tüm resolver lar bu sınıftan extends edilir.

export default abstract class XhrResponseResolver {
    resolve(xhr : XMLHttpRequest) : object { return { }; }
}