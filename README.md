# MDP-DAA
Framework to solve Maximum Diversity Problem using different algorithms for DAA subject in ULL
# MaximumDiversityProblem

# Introduction

The Maximum Diversity Problem aims to find the subset of elements with maximum diversity from a given set of elements. 
Given a set $S = \{s_1, s_2, s_3, \ldots, s_n\}$, where each element is a vector of dimension $k$, and $d_{ij}$
represents the distance between elements $i$ and $j$. With $m < n$ being the size of the solution subset of the problem, 
the objective is to find:

Maximize: $$z = \sum_{i=1}^{n-1} \sum_{j=i+1}^{n} d_{ij} x_i x_j$$

Subject to:
$$\sum_{i=1}^{n} x_i = m$$
$$x_i \in \{0, 1\} \) for all \( i = 1, 2, \ldots, n$$

Where:
- $x_i$:
  - $1$ if it belongs to the solution
  - $0$ otherwise

The distance $d_{ij}$ depends on the specific application context, on this case, we will use the euclid distance.

## Code Explanation
In this implementation, object-oriented programming with C# has been used without the use of any external libraries.
- **Class Problem:** Represents the MDP and stores information like the number of elements, size of an element, and a matrix of doubles representing each element as a list of doubles.
- **Class Solution:** Represents a solution to the MDP, storing information like the number of elements, size, solution value (diversity), number of expanded nodes, and a matrix of doubles for the elements in the solution.
- **Class Partial Solution:** Similar to Clase Solution but uses lists of integers to store indices of elements in the partial solution.
- **Developed Algorithms:** Three algorithms and a local search have been implemented, detailed below:
  - Greedy
  The 'Greedy' class implements a greedy algorithm with a Restricted Candidate List. To solve the problem purely greedily, the RCL size is assigned to 1 by default, making the algorithm behave like a traditional greedy algorithm.

  - Grasp
  The 'Grasp' class implements a GRASP algorithm. The 'Solve' method takes the RCL size for the constructive phase and the solution size to be found as parameters. The implemented local searche is **SWAP:** The performed move is swapping an element that is in the solution with one that is not.

  - Branch and Bound
  The 'BranchAndBound' class implements the Branch and Bound algorithm. During the algorithm's development, we use a 'PartialSolution' class to store the partial solutions generated as we explore the solution tree. In Branch and Bound for maximization, two bounds are used, a lower and an upper one. The lower bound is obtained as the diversity value of a given initial solution and is updated each time a partial solution of full size is explored, if the diversity of that complete solution is greater than the current lower bound. The upper bound is calculated for each partial solution following the formula explained in this article. It proposes three ways to calculate the upper bound:
  - The first consists of adding to the diversity of the partial solution the value of the maximum diversity that a new element (not already in the solution) could contribute, multiplied by the number of elements missing for the partial solution to reach the maximum allowed size.
  - The second involves adding to the diversity of the partial solution the value of the maximum diversity among all candidate elements (these are the elements of the problem that are not in the partial solution) multiplied by the number of elements missing for the partial solution to reach the maximum allowed size.
  - The third strategy (which is the one employed in this case) consists of combining the two previous ideas to obtain a maximum value that is multiplied by a 'weight', calculated based on the number of elements left to add, and is then added to the diversity of the partial solution.

## Results

### Greedy Algorithm Results

| Problema    | n elements | K size | m max elements | z diversity Solution | Time  |
|-------------|------------|--------|----------------|----------------------|-------|
| max_div_15_2.txt | 15         | 2      | 2              | 11,85     | 0     |
| max_div_15_2.txt | 15         | 2      | 3              | 25,72    | 0     |
| max_div_15_2.txt | 15         | 2      | 4              | 86,59     | 0     |
| ...         | ...        | ...    | ...            | ...                  | ...   |
| max_div_30_2.txt | 30         | 2      | 3              | 52,77     | 0     |
| max_div_30_2.txt | 30         | 2      | 4              | 98,48    | 0     |
| max_div_30_2.txt | 30         | 2      | 5              | 14,16         | 0     |


### Grasp Algorithm Results

| Problema        | n elements | K | m max elements | iters | z diversity Solution | Time |
|-----------------|------------|---|----------------|-------|---------------------|------|
| max_div_15_2.txt | 15        | 2 | 2              | 10    | 11,859              | 0    |
| max_div_15_2.txt | 15        | 2 | 2              | 10    | 11,632              | 0    |
| max_div_15_2.txt | 15        | 2 | 2              | 20    | 10,98               | 0    |
| ...              | ...       |...| ...            | ...   | ...                 | ...  |
| max_div_30_3.txt | 30        | 3 | 5              | 10    | 85,014              | 1    |
| max_div_30_3.txt | 30        | 3 | 5              | 20    | 97,964              | 1    |
| max_div_30_3.txt | 30        | 3 | 5              | 20    | 98,58               | 1    |


### Branch and Bound Greedy - Depth First

| Problema        | n elements | K  | m max elements | z diversity Solution | Time | Nodes |
|-----------------|------------|----|----------------|----------------------|------|-------|
| max_div_15_2.txt | 15         | 2  | 2              | 11,859215             | 2    | 119   |
| max_div_15_2.txt | 15         | 2  | 3              | 27,372700             | 0    | 413   |
| max_div_15_2.txt | 15         | 2  | 4              | 49,826781             | 3    | 1559  |
| ...             | ...        | ...| ...            | ...                  | ...  | ...   |
| max_div_30_3.txt | 30         | 3  | 3              | 34,29052            | 8    | 1831  |
| max_div_30_3.txt | 30         | 3  | 4              | 63,701960         | 56    | 9533 |
| max_div_30_3.txt | 30         | 3  | 5              | 99,592041             | 518   | 52363 |


### Branch and Bound Greedy - Tightest Bound

| Problema | n elements | K | m max elements | z diversity | Time | Nodes |
|----------|------------|---|----------------|-------------|------|-------|
{Insert Branch and Bound Greedy - Tightest Bound Results Table Here}

### Branch and Bound Grasp - Depth First

| Problema | n elements | K | m max elements | z diversity | Time | Nodes |
|----------|------------|---|----------------|-------------|------|-------|
{Insert Branch and Bound Grasp - Depth First Results Table Here}

### Branch and Bound Grasp - Tightest Bound

| Problema | n elements | K | m max elements | z diversity | Time | Nodes |
|----------|------------|---|----------------|-------------|------|-------|
{Insert Branch and Bound Grasp - Tightest Bound Results Table Here}




## 4. Conclusions

Given that the instances of the given problem are sufficiently small, the greedy algorithm usually finds the optimal value. It is for this reason, and due to the very low number of iterations it goes through, that the grasp algorithm can end up finding solutions that are equal to or even worse than the greedy algorithm, except when the greedy algorithm does not find the optimal value. In such cases, it is much more likely that the grasp will improve the solution provided by the Greedy algorithm.
The Branch and Bound algorithm always finds the optimal solution, but it is noticeable that fewer nodes are generated if it starts from the greedy solution. Furthermore, if depth-first expansion is used, it generates an even smaller number of nodes. It is evident that the computing time increases more with the size of the problem than with the increase in the maximum allowed solution size. It may seem counterintuitive that solutions to problems with larger elements are faster and generate fewer nodes than their counterparts with smaller elements.
