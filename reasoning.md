# Reasoning and Decision Explanation

This document aims to capture my thought process and approach when building this project.

## Guiding Principles

1. **Focus on learning**  
   My aim for this project was to learn more about the .NET environment and building projects with GitHub, so my decision-making and approach are tailored toward learning from the ground up and taking a simplistic approach rather than focusing on optimization or adhering strictly to standards seen in similar projects.

2. **Clarity over perfection**  
   Because my goal was learning, I opted for the simplest ways to solve problems and interact with my solution. For example, I saw that Blazor is often used in similar projects, but I chose the .NET web template instead. Some areas of my code might seem clunky or overly verbose because I was trying to understand each line rather than optimize it.

3. **My solutions over available solutions**  
   While this is a common project used in assessments and tests and thus has arguably “perfect” solutions online, I opted not to consult outside sources. The project reflects my own approach rather than being perfect or the best possible solution found online.

4. **Iterative approach**  
   I like to build something functional first and then come back to improve it. This often means there are scattered bits of old solutions still present in new solutions, or pieces that don’t fully link up, as they were designed before new solutions were tested and integrated.

## Notes on Approach

- **First, build a page with C# interaction**  
  My first goal was to have an HTML page that could interact with C# logic, giving me room to explore and learn the system before creating more complexity. This started with a call-and-response system that generated and displayed a random number on the page via a button click.

- **Manual build-up**  
  I then decided that displaying the right things would help me better see the logic patterns, so I manually planned responses rather than writing a full logic controller. This mostly worked, had severe limitations, but helped me identify patterns to apply in the next stage. I, however, didn't want to be stuck writing a massive list of if blocks for every outcome and wanted something more modular that could hopefully be expanded on or optimised later on.

- **Patterns and issues**  
  I had my patterns in mind and got the system working, but the logic had many issues that needed patching. Originally, my logic worked with the positions of numbers, using modulo to add sections like "HUNDRED" (position % 3 == 0). This worked well until trailing zeros broke the system. Patching each problem individually became harder than replacing the system with a “group by three” approach, which is used in the final version.

- **Testing Issues**  
  I had a decent amount of trouble setting up testing for the project, and it is still something I need more time to become properly capable at. I made the decision not to include tests thus far. I did review my testing plan and think it would form a great starting point for creating tests in the future.
