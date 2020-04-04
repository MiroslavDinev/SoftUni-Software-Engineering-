function solve(arr) {
    function comparator(width, height) {
        let rectangle = {
            width,
            height,
            area: () => rectangle.width * rectangle.height,
            compareTo: function (other) {
                let result = other.area() - rectangle.area();
                return result || (other.width - rectangle.width);
            }
        };

        return rectangle;
    }

    let allRectangles = [];

    for (const [width, height] of arr) {
        let rectangle = comparator(width, height);
        allRectangles.push(rectangle);
    }

    return allRectangles.sort((a, b) => a.compareTo(b));
}

console.log(
    solve([
        [10, 5],
        [5, 12]
    ])
);