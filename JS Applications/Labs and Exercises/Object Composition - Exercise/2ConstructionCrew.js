function solve(worker) {
    if (worker.dizziness === false) {
        return worker;
    } else {
        worker.levelOfHydrated = (0.1 * worker.weight * worker.experience) + worker.levelOfHydrated;
        worker.dizziness = false;
        return worker;
    }
}