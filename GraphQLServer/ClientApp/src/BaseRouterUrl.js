let muiPaths;

export const getBaseRouterUrl = () => {

    let baseUrls = muiPaths.trim().split(' ');
    baseUrls.push('/');

    const baseUrl = baseUrls.find(url => window.location.pathname.startsWith(url));
    console.log(baseUrl);
    return baseUrl;
};

export const initBaseRouterUrls = (paths) => {
    muiPaths = paths;

    return getBaseRouterUrl();
};